using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Service;
using PetsHotel.webapp.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            var image = Image.FromStream(advertisementTemplate.FileUpload.InputStream, true, true);
            var byteStream = PetsHotel.webapp.Helpers.ImageConverter.imageToByteArray(image);
            advertisementTemplate.bytePhoto = byteStream;
            var model = new AdvertisementEntity
            {
                Title = advertisementTemplate.Title,
                Description = advertisementTemplate.Description,
                Adress = advertisementTemplate.Adress,
                ValidFrom = advertisementTemplate.ValidFrom,
                ValidTo = advertisementTemplate.ValidTo,
                AnimalTypeId = advertisementTemplate.AnimalTypeId,
                UserId = _identity.UserId,
                PhotoConversion=advertisementTemplate.bytePhoto
             };

            _advertisementService.AddAdvertisement(model);
            _advertisementService.Save();

            return View("~/Views/Home/Index.cshtml");

        }
        [HttpGet]
        public ActionResult DogAdvertisements()
        {
            var photo = _advertisementService.GetAllAdvertisement().Select(p=>p.PhotoConversion).FirstOrDefault();
            var convertedPhoto = PetsHotel.webapp.Helpers.ImageConverter.byteArrayToImage(photo);

            var model = _advertisementService.GetAllAdvertisement().Where(p => p.AnimalTypeId == 1).Select(p => new AdvertisementTemplate
            {
                Title = p.Title,
                Adress = p.Adress,
                Description = p.Description,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,   
                PhotoFromBytes = convertedPhoto
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult CatAdvertisements()
        {
            var model = _advertisementService.GetAllAdvertisement().Where(p=>p.AnimalTypeId==2).Select(p=> new AdvertisementTemplate
            {
                Title = p.Title,
                Adress = p.Adress,
                Description = p.Description,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,
                //fota by sie przydała
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult OtherAdvertisements()
        {
           var model = _advertisementService.GetAllAdvertisement().Where(p=>p.AnimalTypeId==3).Select(p=> new AdvertisementTemplate
           {
               Title = p.Title,
               Adress = p.Adress,
               Description = p.Description,
               ValidFrom = p.ValidFrom,
               ValidTo = p.ValidTo,
               //fota by sie przydała
           }).ToList();

            return View(model);
        }


    }
}