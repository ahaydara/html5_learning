using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.Areas.Movies.ViewModels;
using MovieReviewWebApp.ViewModels;

namespace MovieReviewWebApp.Areas.Movies.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository _movieRepository;
        IGenreRepository _genreRepository;

        public HomeController(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        [ChildActionOnly]
        public ActionResult Nav()
        {
            var action = ControllerContext.ParentActionViewContext.RouteData.Values["action"] as string;
            if (action == null) action = "";

            var vm = new NavigationViewModel
            {
                Action = action
            };
            return PartialView("Nav", vm);
        }

        public ActionResult Index(int? page, string sort, bool? desc)
        {
            if (page == null || page < 0) page = 1;
            if (String.IsNullOrWhiteSpace(sort)) sort = "Title";
            if (desc == null) desc = false;

            var vm = new MovieIndexViewModel
            {
                SortBy = sort,
                SortDesc = desc.Value,
                CurrentPage = page.Value,
                ItemsPerPage = 20,
                DataSource = _movieRepository.All
            };

            return View(vm);
        }

        public ActionResult ByGenre(int? genreID)
        {
            var genres = 
                (from x in _genreRepository.All
                 orderby x.Name
                 select x).ToArray();
            var genre = genres.Where(x=>x.ID==genreID || genreID==null).First();

            var q =
                from x in _genreRepository.All
                where x.ID == genre.ID
                from y in x.Movies
                orderby y.Title
                select y;
            var movies = q.ToArray();

            var vm = new ViewByGenreViewModel
            {
                Genres = genres,
                CurrentGenreID = genre.ID,
                Movies = movies
            };

            return View("ByGenre", vm);
        }

        public ActionResult View(int id)
        {
            var movie = _movieRepository.Find(id);
            return View("View", movie);
        }

        public ActionResult Search()
        {
            return View("Search");
        }
        
        [HttpPost]
        public ActionResult Search(string term)
        {
            term = term ?? "";
            var segments = term.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            IQueryable<Movie> topQ = null;
            foreach (var segment in segments)
            {
                var parts = segment.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var q =
                    from x in _movieRepository.All
                    select x;
                foreach (var part in parts)
                {
                    var tmpPart = part;
                    q =
                        from x in q
                        where x.Title.Contains(tmpPart) || x.Description.Contains(tmpPart)
                        select x;
                }
                if (topQ == null) topQ = q;
                else
                {
                    topQ = topQ.Union(q);
                }
            }
            topQ = topQ ?? Enumerable.Empty<Movie>().AsQueryable();
            var list = topQ.OrderBy(x=>x.Title).Distinct().ToArray();
            return View("SearchResults", list);
        }
    }
}
