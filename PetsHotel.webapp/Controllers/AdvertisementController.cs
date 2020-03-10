using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IAdvertisementService _advertisementService; 

        public AdvertisementController(IIdentityProvider identityProvider, IAdvertisementService advertisementService)
        {
            _identityProvider=identityProvider;
             _advertisementService= advertisementService;
        }
        [HttpGet]
        public ActionResult AddAdvertisement()
        {
            return View("Advertisement");
        }

        [HttpPost]
        public ActionResult AddAdvertisement(AdvertisementTemplate advertisementTemplate)
        {
            var _identity = _identityProvider.Get("identity");

            var model = new AdvertisementEntity
            {
                Title = advertisementTemplate.Title,
                Description = advertisementTemplate.Description,
                Adress = advertisementTemplate.Adress,
                ValidFrom = advertisementTemplate.ValidFrom,
                ValidTo = advertisementTemplate.ValidTo,
                AnimalTypeId = advertisementTemplate.AnimalTypeId,
                UserId = _identity.UserId
            };

            _advertisementService.AddAdvertisement(model);
            _advertisementService.Save();

            return View("~/Views/Home/Index.cshtml");

        }
        [HttpGet]
        public ActionResult DogAdvertisements()
        {
            var model = _advertisementService.GetAllAdvertisement().Select(p => new AdvertisementTemplate
            {
                Title=p.Title,
                Adress=p.Adress,
                Description=p.Description,
                ValidFrom=p.ValidFrom,
                ValidTo=p.ValidTo,
                //fota by sie przydała
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CatAdvertisements()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OtherAdvertisements()
        {
            return View();
        }


    }
}