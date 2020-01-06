using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<AnimalEntity> _repository;

        public AnimalService(IRepository<AnimalEntity> repository)
        {
            _repository = repository;
        }

        public void Add(AnimalEntity entity)
        {
            _repository.Add(entity);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}