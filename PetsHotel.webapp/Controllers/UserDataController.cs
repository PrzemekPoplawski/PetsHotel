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
        public ActionResult Edit(int id)
        {
            var model = _loginService.GetAllLogins().Where(p => p.LoginId == id).Select(p=> new EditViewModel
            {
                PersonId = p.User_UserId.Person_PersonId.PersonId,
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

        //GET
        public ActionResult List()
        {
            //PLAN
            // LISTA UŻYTKOWNIKÓW JSON RESULT
            // USER ID, IMIE, NAZWISKO, ROLA, PRZYCISKI EDYTUJ/USUŃ 
            // NACISKAJAC NA ROLE ROZWINIe NAM SIĘ LISTA
            // I PO WYBORZE OD RAZU ZAPISZE W BAZIE
            // BEZ PRZEŁADOWANIA
            // .ONCHANGE puść ajax.POST(URL, data, ) formacie JSON, JSON RESULT {zapisuje do bazy}
            //ZADANIA
            //1. Lista jako widok imie nazwisko rola przyciski edytuj i usuń
            // kontroler metoda get, widok z listą użytkowników 

            var users = _loginService.GetAllLogins().Select(p => new ShowViewModel {
                LoginId = p.User_UserId.Person_PersonId.PersonId,
                FirstName = p.User_UserId.Person_PersonId.FristName,
                LastName = p.User_UserId.Person_PersonId.LastName,
                Role = p.User_UserId.UserTypeId
            }).ToList();

            return View(users);

        }

    }
}