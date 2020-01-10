using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Animal;
using PetsHotel.webapp.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            var image = Image.FromStream(model.FileUpload.InputStream, true, true);
            var byteStream = PetsHotel.webapp.Helpers.ImageConverter.imageToByteArray(image);
            var animal = new AnimalEntity
            {
                AnimalName = model.AnimalName,
                AnimalType = model.AnimalType,
                DataOfBirth = model.DateOfBirth,
                UserId = identity.UserId,
                //mapowanie obrazka na byte[]
               
            };
            //dodanie entity do bazy byte[] do zapisywania zdjecia 
            //button "Lista twoich zwierzaków" i CRUD zwierzaków 
            // edycja zwierzaka, lista zwierzaka danego uzytkownika wraz z obrazkiem (tu trzeba znaleźć sposób na wyswietlenie obrazka na stronie)

            _animalService.AddAnimal(animal);

            _animalService.Save();

            return View(model);
        }
    }
}