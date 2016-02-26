using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.Areas.Reviews.ViewModels;
using MovieReviewWebApp.Service;
using MovieReviewWebApp.Utility;

namespace MovieReviewWebApp.Areas.Reviews.Controllers
{
    public class ReviewController : Controller
    {
        IMovieRepository _movieRepository;
        IReviewRepository _reviewRepository;
        ICurrentUser _currentUser;
        IReviewerGenreRepository _reviewerGenreRepository;

        public ReviewController(
            IMovieRepository movieRepository,
            IReviewRepository reviewRepository,
            ICurrentUser currentUser,
            IReviewerGenreRepository reviewerGenreRepository)
        {
            _movieRepository = movieRepository;
            _reviewRepository = reviewRepository;
            _currentUser = currentUser;
            _reviewerGenreRepository = reviewerGenreRepository;
        }

        public ActionResult Recent()
        {
            var recentQuery =
                from x in _reviewRepository.All
                orderby x.ReviewDate descending
                select x;
            var recentReviews = recentQuery.Take(10).ToArray();

            var vm = new RecentReviewsViewModel
            {
                Reviews = recentReviews
            };

            return View("Recent", vm);
        }

        public ActionResult All(int? page, string sort, bool? desc)
        {
            if (desc == null) desc = false;
            if (String.IsNullOrEmpty(sort)) sort = "ID";
            if (page == null || page.Value <= 0) page = 1;
            var vm = new AllReviewsViewModel
            {
                SortBy = sort,
                SortDesc = desc.Value,
                CurrentPage = page.Value,
                ItemsPerPage = 20,
                DataSource = _reviewRepository.All
            };
            return View("All", vm);
        }

        [CustomAuthorization(Roles = "RegisteredUser", RolesFriendlyName = "Registered User")]
        public ActionResult ViewByMovie(int id)
        {
            var movie = _movieRepository.Find(id);

            var q =
                from x in _reviewRepository.All
                where x.MovieID == id
                select x;

            var vm = new ReviewsViewByMovieViewModel
            {
                Movie = movie,
                Reviews = q.ToArray()
            };
            return View("ViewByMovie", vm);
        }

        [CustomAuthorization(Roles = "RegisteredUser", RolesFriendlyName = "Registered User")]
        public ActionResult View(int id)
        {
            var review = _reviewRepository.Find(id);

            var vm = new MovieReviewViewModel
            {
                Review = review,
            };

            return View(vm);
        }

        [CustomAuthorization(Roles = "Reviewer")]
        public ActionResult CreateFor(int id)
        {
            var movie = _movieRepository.Find(id);

            if (!CanReviewerReviewGenre(movie.Genres))
            {
                return View("InvalidGenre", PrepareInvalidGenreViewModel(movie.Genres));
            }

            var vm = new CreateReviewViewModel()
            {
                MovieID = movie.ID,
                Movie = movie
            };
            return View("CreateFor", vm);
        }

        private InvalidGenreViewModel PrepareInvalidGenreViewModel(IEnumerable<Genre> list)
        {
            var q =
                from x in _reviewerGenreRepository.All
                where x.UserID == _currentUser.Username
                select x.Genre;

            return new InvalidGenreViewModel
            {
                AllowedGenres = q.ToArray(),
                CurrentMovieGenres = list
            };
        }

        private bool CanReviewerReviewGenre(IEnumerable<Genre> list)
        {
            var ids = list.Select(x => x.ID).ToArray();
            var q =
                from x in _reviewerGenreRepository.All
                where x.UserID == _currentUser.Username && ids.Contains(x.GenreID)
                select x;
            return q.Count() > 0;
        }

        [HttpPost]
        [CustomAuthorization(Roles = "Reviewer")]
        public ActionResult CreateFor(CreateReviewInputModel data)
        {
            var movie = _movieRepository.Find(data.MovieID);

            if (!CanReviewerReviewGenre(movie.Genres))
            {
                return View("InvalidGenre", PrepareInvalidGenreViewModel(movie.Genres));
            }

            var review = new Review
            {
                MovieID = data.MovieID,
                Comment = data.Comment, 
                Stars = data.Stars, 
                ReviewDate = DateTime.Now, 
                UserID = _currentUser.Username
            };
            _reviewRepository.InsertOrUpdate(review);
            _reviewRepository.Save();
            return RedirectToAction("View", new { id = review.ID });
        }

        public ActionResult Search()
        {
            return View("Search");
        }
        
        [HttpPost]
        [PartialViewOnAjax]
        public ActionResult Search(string term)
        {
            term = term ?? "";
            var segments = term.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            IQueryable<Review> topQ = null;
            foreach (var segment in segments)
            {
                var parts = segment.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var q =
                    from x in _reviewRepository.All
                    select x;
                foreach (var part in parts)
                {
                    var tmpPart = part;
                    q =
                        from x in q
                        where x.Movie.Title.Contains(tmpPart) || x.Comment.Contains(tmpPart)
                        select x;
                }
                if (topQ == null) topQ = q;
                else
                {
                    topQ = topQ.Union(q);
                }
            }
            topQ = topQ ?? Enumerable.Empty<Review>().AsQueryable();
            var list = topQ.Distinct().ToArray().OrderBy(x => x.Movie.Title);
            return View("SearchResults", list);
        }
    }
}
