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
            
            _animalService.AddAnimal(animal);

            _animalService.Save();

            return View(model);
        }
        //GET
        public ActionResult MyAnimalsList(int id)
        {
            //id = 3
            var animals = _animalService.GetAllAnimals().Where(p=>p.UserId==id).Select(p => new MyAnilmalsListViewModel
            {
                UserId = id,
                AnimalId = p.AnimalId,
                AnimalName = p.AnimalName,
                AnimalType = p.AnimalType,
                DateOfBirth = p.DataOfBirth
            }).ToList();

            return View(animals);
        }
    }
}