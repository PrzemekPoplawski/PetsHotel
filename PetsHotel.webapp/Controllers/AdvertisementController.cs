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

        [HttpPost]
        public ActionResult AddAdvertisement(AdvertisementTemplate advertisementTemplate)
        {
            var model = new AdvertisementEntity
            {
                Title = advertisementTemplate.Title,
                Description = advertisementTemplate.Description,
                Adress = advertisementTemplate.Adress,
                ValidFrom = advertisementTemplate.ValidFrom,
                ValidTo = advertisementTemplate.ValidTo,
                AnimalTypeId = advertisementTemplate.AnimalTypeId

            };

            _advertisementService.Save();

            return View("~/Views/Shared/_Layout.cshtml");

        }



    }
}