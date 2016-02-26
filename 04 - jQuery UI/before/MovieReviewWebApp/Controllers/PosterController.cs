using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReviewWebApp.Controllers
{
    public class PosterController : Controller
    {
        public ActionResult Index(string id)
        {
            id = id.ToLower();
            id = id.Replace(" ", "");
            if (!id.EndsWith(".jpg")) id += ".jpg";
            
            var path = "~/Content/Posters/" + id;
            var filePath = Server.MapPath(path);
            if (System.IO.File.Exists(filePath))
            {
                return File(path, "image/jpeg");
            }
            else
            {
                return File("~/Content/Images/Unknown.png", "image/png");
            }
        }
    }
}
