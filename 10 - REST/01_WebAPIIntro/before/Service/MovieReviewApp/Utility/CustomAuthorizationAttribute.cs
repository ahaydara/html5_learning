using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReviewApp.Utility
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public string RolesFriendlyName { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["RoleRequired"] = "Reviewer";
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["RolesRequired"] = RolesFriendlyName ?? Roles;
            base.HandleUnauthorizedRequest(filterContext);
        }
    }

}