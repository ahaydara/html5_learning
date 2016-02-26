using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.Utility;

namespace MovieReviewWebApp.Areas.Admin.Controllers
{
    [CustomAuthorization(Roles = "Admin")]
    public class ReviewController : Controller
    {
		private readonly IMovieRepository movieRepository;
		private readonly IUserRepository userRepository;
		private readonly IReviewRepository reviewRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ReviewController() : this(new MovieRepository(), new UserRepository(), new ReviewRepository())
        {
        }

        public ReviewController(IMovieRepository movieRepository, IUserRepository userRepository, IReviewRepository reviewRepository)
        {
			this.movieRepository = movieRepository;
			this.userRepository = userRepository;
			this.reviewRepository = reviewRepository;
        }

        //
        // GET: /Review/

        public ViewResult Index()
        {
            return View(reviewRepository.AllIncluding(review => review.Movie));
        }

        //
        // GET: /Review/Details/5

        public ViewResult Details(int id)
        {
            return View(reviewRepository.Find(id));
        }

        //
        // GET: /Review/Create

        public ActionResult Create()
        {
			ViewBag.PossibleMovies = movieRepository.All;
			ViewBag.PossibleUsers = userRepository.All;
            return View();
        } 

        //
        // POST: /Review/Create

        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid) {
                reviewRepository.InsertOrUpdate(review);
                reviewRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleMovies = movieRepository.All;
				ViewBag.PossibleUsers = userRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Review/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleMovies = movieRepository.All;
			ViewBag.PossibleUsers = userRepository.All;
             return View(reviewRepository.Find(id));
        }

        //
        // POST: /Review/Edit/5

        [HttpPost]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid) {
                reviewRepository.InsertOrUpdate(review);
                reviewRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleMovies = movieRepository.All;
				ViewBag.PossibleUsers = userRepository.All;
				return View();
			}
        }

        //
        // GET: /Review/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(reviewRepository.Find(id));
        }

        //
        // POST: /Review/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            reviewRepository.Delete(id);
            reviewRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

