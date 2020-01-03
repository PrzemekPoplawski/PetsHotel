using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<PersonEntity> _personRepository;

        public UserService(IRepository<UserEntity> userRepository, IRepository<PersonEntity> personRepository)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
        }

        public void AddPerson(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddUser(UserEntity entity)
        {
            _userRepository.Add(entity);
        }

        public IQueryable<PersonEntity> GetAllPersons()
        {
            return _personRepository.GetAllValues();
        }

        public IQueryable<UserEntity> GetAllUsers()
        {
            return _userRepository.GetAllValues();
        }

        public void Save()
        {
            _userRepository.Save();
            _personRepository.Save();
        }
    }
}