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

        public UserService(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserEntity entity)
        {
            _userRepository.Add(entity);
        }

        public IQueryable<UserEntity> GetAllUsers()
        {
            return _userRepository.GetAllValues();
        }
    }
}