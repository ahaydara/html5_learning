using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewApp.Models;
using MovieReviewApp.Utility;


namespace MovieReviewApp.Areas.Admin.Controllers
{
    [CustomAuthorization(Roles = "Admin")]
    public class MovieController : Controller
    {
		private readonly IDirectorRepository directorRepository;
		private readonly ICountryRepository countryRepository;
		private readonly IMovieRepository movieRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public MovieController() : this(new DirectorRepository(), new CountryRepository(), new MovieRepository())
        {
        }

        public MovieController(IDirectorRepository directorRepository, ICountryRepository countryRepository, IMovieRepository movieRepository)
        {
			this.directorRepository = directorRepository;
			this.countryRepository = countryRepository;
			this.movieRepository = movieRepository;
        }

        //
        // GET: /Movie/

        public ViewResult Index()
        {
            return View(movieRepository.AllIncluding(movie => movie.Director, movie => movie.Country, movie => movie.Genres));
        }

        //
        // GET: /Movie/Details/5

        public ViewResult Details(int id)
        {
            return View(movieRepository.Find(id));
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
			ViewBag.PossibleDirectors = directorRepository.All;
			ViewBag.PossibleCountries = countryRepository.All;
            return View();
        } 

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid) {
                movieRepository.InsertOrUpdate(movie);
                movieRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleDirectors = directorRepository.All;
				ViewBag.PossibleCountries = countryRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Movie/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleDirectors = directorRepository.All;
			ViewBag.PossibleCountries = countryRepository.All;
             return View(movieRepository.Find(id));
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid) {
                movieRepository.InsertOrUpdate(movie);
                movieRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleDirectors = directorRepository.All;
				ViewBag.PossibleCountries = countryRepository.All;
				return View();
			}
        }

        //
        // GET: /Movie/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(movieRepository.Find(id));
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            movieRepository.Delete(id);
            movieRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

