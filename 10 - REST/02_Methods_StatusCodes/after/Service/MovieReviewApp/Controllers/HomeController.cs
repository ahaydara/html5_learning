using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewApp.ViewModels;
using MovieReviewApp.Service;
using System.Web.Security;
using System.Web.UI;

namespace MovieReviewApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ICurrentUser _currentUser;

        public HomeController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.SetAuthCookie("Admin", false);
                return RedirectToAction("Index");
            }

            var db = new Models.MovieWebAppDBContext();
            var movies = db.Movies.ToArray();
            return View();
        }

        [ChildActionOnly]
        public ActionResult Nav()
        {
            var area = ControllerContext.ParentActionViewContext.RouteData.DataTokens["area"] as string;
            if (area == null || area == "") area = "";
            
            var vm = new NavigationViewModel()
            {
                Admin = _currentUser.IsInRole("Admin"),
                Area = area
            };
            return PartialView("Nav", vm);
        }

        [ChildActionOnly]
        public ActionResult CurrentUserInfo()
        {
            return PartialView("CurrentUserInfo", _currentUser);
        }
    }
}
