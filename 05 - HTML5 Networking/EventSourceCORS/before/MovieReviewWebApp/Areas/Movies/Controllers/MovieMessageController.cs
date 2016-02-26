using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.Utility;
using System.Threading.Tasks;
using System.IO;

namespace MovieReviewWebApp.Areas.Movies.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class MovieMessageController : AsyncController
    {
        IMovieRepository _movieRepository;
        IGenreRepository _genreRepository;

        public MovieMessageController(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        static object GetMovieReviewData(int id, IMovieRepository movieRepository = null)
        {
            if (movieRepository == null)
            {
                movieRepository = System.Web.Mvc.DependencyResolver.Current.GetService<IMovieRepository>();
            }
            var q =
                from x in movieRepository.All
                where x.ID == id
                select x.Reviews;
            var reviews = q.FirstOrDefault();
            if (reviews.Count == 0)
            {
                return new { NumberOfReviews = 0 };
            }
            else
            {
                var avg = reviews.Average(x => x.Stars);
                var latestReview = reviews.OrderByDescending(x => x.ReviewDate).FirstOrDefault();
                var dt = latestReview.ReviewDate.Ticks;
                return new { MovieID = id, NumberOfReviews = reviews.Count, AverageStars = avg, LastReviewDate = dt };
            }
        }

        static string GetMovieReviewDataJson(int id, IMovieRepository movieRepository = null)
        {
            var data = GetMovieReviewData(id, movieRepository);
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(data);
        }

        [HttpPost]
        public ActionResult GetMovieReviewInfo(int id)
        {
            return Json(GetMovieReviewData(id, _movieRepository));
        }

        public void GetMovieReviewInfoEventAsync()
        {
            RegisterEventSourceClient(this);
        }

        public ActionResult GetMovieReviewInfoEventCompleted()
        {
            return new EmptyResult();
        }

        static MovieMessageController()
        {
            MovieReviewWebApp.Areas.Reviews.Controllers.ReviewController.ReviewCreated +=
                (sender, eventArgs) =>
                {
                    Task.Factory.StartNew(() =>
                    {
                        NotifyEventSourceClientsForReview(eventArgs.MovieID);
                    });
                };
        }

        private static void NotifyEventSourceClientsForReview(int movieID)
        {
            var json = GetMovieReviewDataJson(movieID);
            var list = _clients.ToArray();
            foreach (var controller in list)
            {
                controller.NotifyClient(movieID, json);
            }
        }

        void NotifyClient(int movieID, string json)
        {
            try
            {
                AsyncManager.Sync(() =>
                {
                    try
                    {
                        if (Response.IsClientConnected)
                        {
                            //Response.Output.WriteLine("event:" + movieID.ToString());
                            Response.Output.WriteLine("data:" + json);
                            Response.Output.WriteLine();
                            Response.Output.Flush();
                        }
                        else
                        {
                            UnregisterEventSourceClient(this);
                        }
                    }
                    catch
                    {
                        UnregisterEventSourceClient(this);
                    }
                });
            }
            catch
            {
                UnregisterEventSourceClient(this);
            }
        }

        static List<MovieMessageController> _clients = new List<MovieMessageController>();
        static void RegisterEventSourceClient(MovieMessageController controller)
        {
            controller.AsyncManager.OutstandingOperations.Increment();
            controller.HttpContext.Server.ScriptTimeout = (int)TimeSpan.FromHours(1).TotalSeconds;
            controller.Response.ContentType = "text/event-stream";
            controller.Response.BufferOutput = false;
            controller.Response.Output.WriteLine();
            controller.Response.Output.WriteLine();
            
            lock (_clients)
            {
                _clients.Add(controller);
            }
        }
        static void UnregisterEventSourceClient(MovieMessageController movieMessageController)
        {
            lock (_clients)
            {
                _clients.Remove(movieMessageController);
            }
            
            movieMessageController.AsyncManager.OutstandingOperations.Decrement();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            UnregisterEventSourceClient(filterContext.Controller as MovieMessageController);
            filterContext.ExceptionHandled = true;
        }
    }
}
