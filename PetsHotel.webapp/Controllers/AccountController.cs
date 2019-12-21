using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Home;
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

        public AccountController(IUserService service)
        {
            service = _userService;
        }

        [HttpGet]
        public ActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Add() 
        {
            var model = new UserViewModel
            {
                Adres = _userService.GetAllUsers().Select(p => p.Person_PersonId.Address).ToString(),
                FirstName = _userService.GetAllUsers().Select(p => p.Person_PersonId.FristName).ToString(),
                LastName = _userService.GetAllUsers().Select(p => p.Person_PersonId.LastName).ToString(),
                //UserId = _userService.GetAllUsers().Select(p => p.UserId).
            };

            return model;
        }
    }
}