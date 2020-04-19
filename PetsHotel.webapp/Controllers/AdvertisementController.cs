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
        public ActionResult AnimalAdvertisements(int? animalTypeId, string filter)
        {
            var entity = _advertisementService.GetAllAdvertisement().Where(a=>a.AnimalTypeId == animalTypeId).ToList();
            if (filter != null && filter != "")
            {
                entity = _advertisementService.GetAllAdvertisement().Where(p => p.Title.Contains(filter)).ToList();
            }


            var model = entity.Select(p => new AdvertisementTemplate
            {
                Title = p.Title,
                Adress = p.Adress,
                Description = p.Description,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,   
                bytePhoto=p.PhotoConversion,
                AdvertisementId=p.AdvertisementId,
                UserId=p.UserId
            }).ToList();

            return View(model);
        } 

        public ActionResult FilterAdvertisement(string filter = "", int? animalTypeId = null)
        {
            var entity = _advertisementService.GetAllAdvertisement().Where(p => p.AnimalTypeId == animalTypeId).ToList();

            if (filter != null && filter != "")
            {
                entity = _advertisementService.GetAllAdvertisement().Where(p => p.Title.Contains(filter)).ToList();
            }

           return RedirectToAction("AnimalAdvertisements", new {filter, animalTypeId});
        }
       [HttpGet]
        public ActionResult EditAd(int Id)
        {
            var model = _advertisementService.GetAllAdvertisement().Where(p => p.AdvertisementId == Id).Select(p => new AdvertisementTemplate
            {
                Title = p.Title,
                Adress = p.Adress,
                Description = p.Description,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,
                bytePhoto = p.PhotoConversion,
                AdvertisementId = p.AdvertisementId,
                UserId = p.UserId
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditAd(AdvertisementTemplate template,int id)
        {
            var model = _advertisementService.GetAllAdvertisement().Where(p => p.AdvertisementId == id).FirstOrDefault();

            model.Title = template.Title;
            model.Adress = template.Adress;
            model.AnimalTypeId = template.AnimalTypeId;
            model.Description = template.Description;
            model.ValidFrom = template.ValidFrom;
            model.ValidTo = template.ValidTo;
            model.PhoneNumber = template.PhoneNumber;

            _advertisementService.Save();

            return RedirectToAction("AnimalAdvertisements", new { animalTypeId = model.AnimalTypeId } );
        }

    }

    public class FilterClass
    {
        public string Filter { get; set; }
    }
}