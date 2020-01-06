using PetsHotel.webapp.Entity;
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
        // GET: Animal
        public ActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnimal(AddAnimalViewModel model)
        {
            var animal = new AnimalEntity
            {
                AnimalName = model.AnimalName,
                AnimalType = model.AnimalType,
                DataOfBirth = model.DateOfBirth,
                UserId = ident
                
            };

            return View(model);
        }
    }
}