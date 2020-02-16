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

        public ActionResult AnimalList(int id)
        {
            var animals = _animalService.GetAllAnimals().Where(p => p.UserId == id).Select(p => new MyAnilmalsListViewModel
            {
                UserId = id,
                AnimalId = p.AnimalId,
                AnimalName = p.AnimalName,
                AnimalType = p.AnimalType
            }).ToList();

            return Json(animals, JsonRequestBehavior.AllowGet);
        }
        //GET
        public ActionResult MyAnimalsList()
        {
            return View();
            
        }

        public ActionResult TestAnimalList(string search = null)
        {
            IEnumerable<TestAnimalListcs> listaZwierzakow;

            if (search != null)
            {
                listaZwierzakow = TestAnimalListcs.AnimalList().Where(p => p.AnimalName.Contains(search)).ToArray();
            }
            else
                listaZwierzakow = TestAnimalListcs.AnimalList().ToArray();

            if (Request.IsAjaxRequest())
                return PartialView("_TestAnimalList", listaZwierzakow);

            return View(listaZwierzakow);
        }
    }
}