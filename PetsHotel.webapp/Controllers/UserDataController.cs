using PetsHotel.webapp.Service;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Entity;
using PetsHotel.webapp.ViewModels.UserData;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace PetsHotel.webapp.Controllers
{
    public class UserDataController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoginService _loginService;
        private readonly IIdentityProvider _identityProvider;

        public UserDataController(IUserService userService, IIdentityProvider identityProvider, ILoginService loginService)
        {
            _userService = userService;
            _identityProvider = identityProvider;
            _loginService = loginService;
        }

        // GET: UserData
        public ActionResult Edit()
        {
            var identity = _identityProvider.Get("identity");
            var model = _loginService.GetAllLogins().Where(p => p.LoginId == identity.LoginId).Select(p=> new EditViewModel
            {
                PersonId = identity.PersonId,
                Login = p.UserName,
                FirstName = p.User_UserId.Person_PersonId.FristName,
                LastName = p.User_UserId.Person_PersonId.LastName,
                Email = p.User_UserId.Person_PersonId.Email,
                Address = p.User_UserId.Person_PersonId.Address,
                PhoneNumber = p.User_UserId.Person_PersonId.PhoneNumber,
                SexCode = p.User_UserId.Person_PersonId.SexCode.ToString()                
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            byte sexCode;
            byte.TryParse(model.SexCode, out sexCode);           

            var person  = _userService.GetAllPersons().Where(p => p.PersonId == model.PersonId).FirstOrDefault();
            person.FristName = model.FirstName.Trim();
            person.LastName = model.LastName.Trim();
            person.PhoneNumber = PreparePhoneNumber(model.PhoneNumber);
            person.Address = model.Address;
            person.Email = model.Email.Trim();
            person.SexCode = sexCode;

            _userService.Save();

            return RedirectToAction("Index", "Home");
        }

        private string PreparePhoneNumber(string phoneNumber)
        {
            return phoneNumber.Replace("-", "").Replace(" ", "").Replace("+", "").Trim();
        }


    }
}