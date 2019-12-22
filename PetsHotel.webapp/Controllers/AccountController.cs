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
        public ActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Add(SignUpViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            // personEntity -> ID
            // new userEntity -> 
            _loginService.CreateLogin(model.Login, model.Password, model.Email);
            
      
            return View();
        }
    }
}