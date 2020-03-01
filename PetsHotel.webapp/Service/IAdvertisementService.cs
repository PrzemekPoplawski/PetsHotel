using PetsHotel.webapp.Entity;
using PetsHotel.webapp.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Service
{
    public interface IAdvertisementService
    {
        void AddAdvertisement(AdvertisementEntity advertisementTemplate);
        IQueryable<AdvertisementEntity> GetAllAdvertisement();
        void Save();
    }
}