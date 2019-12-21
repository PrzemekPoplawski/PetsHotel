using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Home;

namespace PetsHotel.webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            
            var model = new List<UserViewModel>
            {
                new UserViewModel
                {
                    FirstName = "Przemo",
                LastName = "Popławski",
                Adres = "Wola"
                },
                new UserViewModel
                {
                    FirstName = "Przemo",
                LastName = "Popławski",
                Adres = "Wola"
                }
                ,new UserViewModel
                {
                    FirstName = "Przemo",
                LastName = "Popławski",
                Adres = "Wola"
                }

            };
            return View(model);
        }


        public ActionResult About()
        { 
            ViewBag.Message = "Your application description page.";

            var users = _userService.GetAllUsers();

            var model = new UserViewModel()
            {
                FirstName = "Michał",
                LastName = "Wojciechowski",
                UserId = 1
            };

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
           
        }
    }
    // Entity

    // LoginEntity
    // UserEntity
    //


    //REPOZYTORUM 
    // CRUD
    // Repository.cs

    // Repositories
    // Reposiotry.cs
    // IRepository.cs
    // CREATE DELETE UPDATE READ
    
}