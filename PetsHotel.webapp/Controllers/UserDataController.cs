using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.UsersData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Controllers
{
    public class UserDataController : Controller
    {
        private readonly IUsersDataService _userDataService;

        public UserDataController(IUsersDataService userDataService)
        {
            userDataService = _userDataService;
        }

        // GET: UserData
        public ActionResult UsersData()
        {
            return View("UsersData");
        }

        [HttpPost]
        public ActionResult UserData(UserDataViewModel users)
        {
            if (!ModelState.IsValid)
            {
                return View(new UserDataViewModel { Login = users.Login });
            }

            var usrsDetails = _userDataService.GetAllUsers().FirstOrDefault();

            var userDatas = new UserDataViewModel
            {
                FirstName= users.FirstName,
                LastName = usrsDetails.Person_PersonId.LastName,
                Email = usrsDetails.Person_PersonId.Email
            };

            
            return RedirectToAction("Index", "Home");
        }


    }
}