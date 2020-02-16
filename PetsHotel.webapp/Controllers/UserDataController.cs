using PetsHotel.webapp.Service;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Entity;
using PetsHotel.webapp.ViewModels.UserData;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetsHotel.webapp.Helpers;

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

        private Roles _roles;
        private Roles GetRole()
        {
            if (_roles == null)
                _roles = new Roles(_identityProvider);
            return _roles;
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
                SexCode = p.User_UserId.Person_PersonId.SexCode,
                RoleId = p.User_UserId.UserTypeId
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.GetAllUsers().Where(p => p.PersonId == model.PersonId).FirstOrDefault();
            var person  = _userService.GetAllPersons().Where(p => p.PersonId == model.PersonId).FirstOrDefault();
            person.FristName = model.FirstName.Trim();
            person.LastName = model.LastName.Trim();
            person.PhoneNumber = PreparePhoneNumber(model.PhoneNumber);
            person.Address = model.Address;
            person.Email = model.Email.Trim();
            person.SexCode = model.SexCode;
            user.UserTypeId = model.RoleId;
            
            _userService.Save();

            if(GetRole().IsAdmin)
                return RedirectToAction("List", "UserData");

            return RedirectToAction("Index", "Home");
        }

        //do klasy przetwarzania danych ?
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
                PersonId = p.User_UserId.Person_PersonId.PersonId,
                FirstName = p.User_UserId.Person_PersonId.FristName,
                LastName = p.User_UserId.Person_PersonId.LastName,
                RoleId = p.User_UserId.UserTypeId,
                UserName = p.UserName
                }).ToList();

            return View(users);

        }

        [HttpPost]
        public ActionResult UpdateName(int id,string value)
        {
            var person = _userService.GetAllPersons().Where(p => p.PersonId == id).FirstOrDefault();
            person.FristName = value;

            _userService.Save();

            return Json(new { success = true, responseText = "User updated" });
        }

        [HttpPost]
        public ActionResult UpdateLastName(int id, string value)
        {
            var person = _userService.GetAllPersons().Where(p => p.PersonId == id).FirstOrDefault();
            person.FristName = value;

            _userService.Save();

            return Json(new { success = true, responseText = "User updated" });
        }

    }
}