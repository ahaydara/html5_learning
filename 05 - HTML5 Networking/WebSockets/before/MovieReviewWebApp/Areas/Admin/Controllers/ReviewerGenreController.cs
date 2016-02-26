using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;


namespace MovieReviewWebApp.Areas.Admin.Controllers
{   
    public class ReviewerGenreController : Controller
    {
		private readonly IUserRepository userRepository;
		private readonly IGenreRepository genreRepository;
		private readonly IReviewerGenreRepository reviewergenreRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ReviewerGenreController() : this(new UserRepository(), new GenreRepository(), new ReviewerGenreRepository())
        {
        }

        public ReviewerGenreController(IUserRepository userRepository, IGenreRepository genreRepository, IReviewerGenreRepository reviewergenreRepository)
        {
			this.userRepository = userRepository;
			this.genreRepository = genreRepository;
			this.reviewergenreRepository = reviewergenreRepository;
        }

        //
        // GET: /ReviewerGenre/

        public ViewResult Index()
        {
            return View(reviewergenreRepository.AllIncluding(reviewergenre => reviewergenre.Genre));
        }

        //
        // GET: /ReviewerGenre/Details/5

        public ViewResult Details(int id)
        {
            return View(reviewergenreRepository.Find(id));
        }

        //
        // GET: /ReviewerGenre/Create

        public ActionResult Create()
        {
			ViewBag.PossibleUsers = userRepository.All.Where(x=>x.IsRoleReviewer==true);
			ViewBag.PossibleGenres = genreRepository.All;
            return View();
        } 

        //
        // POST: /ReviewerGenre/Create

        [HttpPost]
        public ActionResult Create(ReviewerGenre reviewergenre)
        {
            if (ModelState.IsValid) {
                reviewergenreRepository.InsertOrUpdate(reviewergenre);
                reviewergenreRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.PossibleUsers = userRepository.All.Where(x => x.IsRoleReviewer == true);
				ViewBag.PossibleGenres = genreRepository.All;
				return View();
			}
        }
        
        //
        // GET: /ReviewerGenre/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.PossibleUsers = userRepository.All.Where(x => x.IsRoleReviewer == true);
			ViewBag.PossibleGenres = genreRepository.All;
             return View(reviewergenreRepository.Find(id));
        }

        //
        // POST: /ReviewerGenre/Edit/5

        [HttpPost]
        public ActionResult Edit(ReviewerGenre reviewergenre)
        {
            if (ModelState.IsValid) {
                reviewergenreRepository.InsertOrUpdate(reviewergenre);
                reviewergenreRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.PossibleUsers = userRepository.All.Where(x => x.IsRoleReviewer == true);
				ViewBag.PossibleGenres = genreRepository.All;
				return View();
			}
        }

        //
        // GET: /ReviewerGenre/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(reviewergenreRepository.Find(id));
        }

        //
        // POST: /ReviewerGenre/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            reviewergenreRepository.Delete(id);
            reviewergenreRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

