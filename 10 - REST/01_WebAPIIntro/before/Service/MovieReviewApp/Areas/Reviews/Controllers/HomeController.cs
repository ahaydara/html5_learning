using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewApp.Models;
using MovieReviewApp.Service;
using MovieReviewApp.Areas.Reviews.ViewModels;
using MovieReviewApp.ViewModels;

namespace MovieReviewApp.Areas.Reviews.Controllers
{
    public class HomeController : Controller
    {
        IReviewRepository _reviewRepository;
        IDateTime _now;
        public HomeController(
            IReviewRepository reviewRepository, 
            IDateTime now)
        {
            _reviewRepository = reviewRepository;
            _now = now;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Recent", "Review");
            //return View();
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
    }
}
