using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IAnimalService _animalService;

        public AnimalController(IIdentityProvider identityProvider, IAnimalService animalService)
        {
            _identityProvider = identityProvider;
            _animalService = animalService;
        }

        // GET: Animal
        public ActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnimal(AddAnimalViewModel model)
        {
          var identity = _identityProvider.Get("identity");

            var animal = new AnimalEntity
            {
                AnimalName = model.AnimalName,
                AnimalType = model.AnimalType,
                DataOfBirth = model.DateOfBirth,
                UserId = identity.UserId
               
            };

            _animalService.AddAnimal(animal);

            _animalService.Save();

            return View(model);
        }
    }
}