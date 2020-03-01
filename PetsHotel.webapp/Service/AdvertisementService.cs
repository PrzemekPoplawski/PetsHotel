using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.ViewModels.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IRepository<AdvertisementEntity> _advertisementRepository;

        public AdvertisementService(IRepository<AdvertisementEntity> advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public void AddAdvertisement(AdvertisementEntity advertisementEntity)
        {
            _advertisementRepository.Add(advertisementEntity);
        }

        public IQueryable<AdvertisementEntity> GetAllAdvertisement()
        {
            return _advertisementRepository.GetAllValues();
        }

        public void Save()
        {
            _advertisementRepository.Save();
        }

    }


}