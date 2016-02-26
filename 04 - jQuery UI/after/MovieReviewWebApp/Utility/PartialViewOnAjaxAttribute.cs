using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReviewWebApp.Utility
{
    public class PartialViewOnAjaxAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var vr = filterContext.Result as ViewResult;
            if (vr != null && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var pv = new PartialViewResult
                {
                    ViewName = vr.ViewName, TempData = vr.TempData, ViewData = vr.ViewData
                };
                filterContext.Result = pv;
            }
        }
    }
}