using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.Utility;

namespace MovieReviewWebApp.Areas.Admin.Controllers
{   
    [CustomAuthorization(Roles="Admin")]
    public class CountryController : Controller
    {
		private readonly ICountryRepository countryRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CountryController() : this(new CountryRepository())
        {
        }

        public CountryController(ICountryRepository countryRepository)
        {
			this.countryRepository = countryRepository;
        }

        //
        // GET: /Country/

        public ViewResult Index()
        {
            return View(countryRepository.All);
        }

        //
        // GET: /Country/Details/5

        public ViewResult Details(int id)
        {
            return View(countryRepository.Find(id));
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid) {
                countryRepository.InsertOrUpdate(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Country/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(countryRepository.Find(id));
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid) {
                countryRepository.InsertOrUpdate(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Country/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(countryRepository.Find(id));
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            countryRepository.Delete(id);
            countryRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

