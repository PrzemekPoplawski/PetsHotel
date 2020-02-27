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
        public AdvertisementController()
        {

        }

        [HttpGet]
        public PartialViewResult AddAdvertisement()
        {
            var model = new AdvertisementTemplate();
           
            if(false)
            {
                model = new AdvertisementTemplate()
                {
                    Title = "tytuł",
                    Adress = "adress",
                    AnimalId = 3,
                    Description = "opis",
                    PhoneNumber = 6546546
                };
            }
            return PartialView(model);
        }

        
    }
}