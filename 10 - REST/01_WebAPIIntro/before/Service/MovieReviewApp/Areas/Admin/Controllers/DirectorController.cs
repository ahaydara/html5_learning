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
    public class DirectorController : Controller
    {
		private readonly IDirectorRepository directorRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public DirectorController() : this(new DirectorRepository())
        {
        }

        public DirectorController(IDirectorRepository directorRepository)
        {
			this.directorRepository = directorRepository;
        }

        //
        // GET: /Director/

        public ViewResult Index()
        {
            return View(directorRepository.All);
        }

        //
        // GET: /Director/Details/5

        public ViewResult Details(int id)
        {
            return View(directorRepository.Find(id));
        }

        //
        // GET: /Director/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Director/Create

        [HttpPost]
        public ActionResult Create(Director director)
        {
            if (ModelState.IsValid) {
                directorRepository.InsertOrUpdate(director);
                directorRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Director/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(directorRepository.Find(id));
        }

        //
        // POST: /Director/Edit/5

        [HttpPost]
        public ActionResult Edit(Director director)
        {
            if (ModelState.IsValid) {
                directorRepository.InsertOrUpdate(director);
                directorRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Director/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(directorRepository.Find(id));
        }

        //
        // POST: /Director/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            directorRepository.Delete(id);
            directorRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

