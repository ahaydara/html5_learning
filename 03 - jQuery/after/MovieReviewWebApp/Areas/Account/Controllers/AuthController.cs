using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewWebApp.Service;
using MovieReviewWebApp.ViewModels;

namespace MovieReviewWebApp.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        ICurrentUser _currentUser;
        IAuthentication _authentication;

        public AuthController(
            ICurrentUser currentUser,
            IAuthentication authentication)
        {
            _currentUser = currentUser;
            _authentication = authentication;
        }

        public ActionResult Login(string returnUrl)
        {
            var roles = TempData["RolesRequired"] as string;
            var vm = new AccountLoginViewModel()
            {
                ReturnUrl = returnUrl,
                RolesRequired = roles
            };
            if (_currentUser.IsLoggedIn)
            {
                vm.Username = _currentUser.Username;
                vm.ShowWarning = true;
            }

            return View("Login", vm);
        }

        [HttpPost]
        public ActionResult Login(AccountLoginInputModel input)
        {
            if (ModelState.IsValid)
            {
                if (_authentication.Authenticate(input.Username, input.Password))
                {
                    _currentUser.Login(input.Username);
                    if (!String.IsNullOrEmpty(input.ReturnUrl) && Url.IsLocalUrl(input.ReturnUrl))
                    {
                        return Redirect(input.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return Login(input.ReturnUrl);
        }

        public ActionResult Logout()
        {
            if (_currentUser.IsLoggedIn)
            {
                _currentUser.Logout();
                return RedirectToAction("Logout");
            }

            return View("Logout");
        }
    }
}
