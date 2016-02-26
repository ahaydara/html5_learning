using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewApp.Service;
using MovieReviewApp.Areas.Account.Models;
using System.ComponentModel.DataAnnotations;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Account.Controllers
{
    public class HomeController : Controller
    {
        ICurrentUser _currentUser;
        IAuthentication _authentication;
        IUserRepository _userRepository;

        public HomeController(
            ICurrentUser currentUser, 
            IAuthentication authentication,
            IUserRepository userRepository)
        {
            _currentUser = currentUser;
            _authentication = authentication;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            if (_currentUser.IsLoggedIn)
            {
                return View("LoggedIn");
            }
            else
            {
                return View("Anonymous");
            }
        }

        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }
        
        [HttpPost]
        public ActionResult CreateAccount(CreateAccountInputModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authentication.Register(input.Username, input.Password, input.Email);
                    _currentUser.Login(input.Username);
                    return RedirectToAction("CreateAccountSuccess");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return CreateAccount();
        }
        
        public ActionResult CreateAccountSuccess()
        {
            return View("CreateAccountSuccess");
        }

        [Authorize]
        public ActionResult Profile()
        {
            var user = _userRepository.Find(_currentUser.Username);
            return View("Profile", user);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult Profile(string firstName, string lastName)
        {
            var user = _userRepository.Find(_currentUser.Username);
            user.FirstName = firstName;
            user.LastName = lastName;
            _userRepository.Save();
            TempData["Message"] = "Update Successful";
            return RedirectToAction("Index");
        }
    }
}
