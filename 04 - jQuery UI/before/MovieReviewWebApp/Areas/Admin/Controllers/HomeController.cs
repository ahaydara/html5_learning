using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Areas.Admin.ViewModels;
using MovieReviewWebApp.Utility;

namespace MovieReviewWebApp.Areas.Admin.Controllers
{
    [CustomAuthorization(Roles = "Admin")]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Nav()
        {
            var controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"] as string;
            if (controller == null) controller = "";
            
            var vm = new AdminNavViewModel
            {
                AdminController = "admin-" + controller.ToLower()
            };
            return PartialView("Nav", vm);
        }
    }
}
