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
        private readonly IRepository<AnimalEntity> _animalRepository;

        public AnimalService(IRepository<AnimalEntity> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void AddAnimal(AnimalEntity entity)
        {
            _animalRepository.Add(entity);
        }

        public IQueryable<AnimalEntity> GetAllAnimals()
        {
           return _animalRepository.GetAllValues();
        }

        public void Save()
        {
            _animalRepository.Save();
        }

    }
}