using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MovieReviewWebApp.Service
{
    public class FormsAuthCurrentUser : ICurrentUser
    {
        public bool IsLoggedIn
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public string Username
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public void Login(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
        
        public bool IsInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }
    }
}