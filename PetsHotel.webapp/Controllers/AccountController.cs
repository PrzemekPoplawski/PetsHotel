using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoginService _loginService;

        public AccountController(IUserService userService, ILoginService loginService)
        {
            _userService = userService;
            _loginService = loginService;
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Views()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _loginService.CreateLogin(model.Login, model.Password, model.Email);

            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new SignInViewModel() {Login = model.Login});
            }
            
            if (!_loginService.Authenticate(model.Login, model.Password))
            {
                ModelState.AddModelError("wrongLoginData", "Nieprawidłowy login lub hasło.");
                return View(new SignInViewModel() { Login = model.Login });
            }
            
            return RedirectToAction("Index","Home");
        }

        public ActionResult LogOut()
        {
            _loginService.LogOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
