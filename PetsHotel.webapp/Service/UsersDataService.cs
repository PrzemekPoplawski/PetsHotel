using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.ViewModels.UsersData;

namespace PetsHotel.webapp.Service
{
    public class UsersDataService : IUsersDataService
    {
        private readonly IRepository<UserEntity> _userDataRespository;

        public UsersDataService(IRepository<UserEntity> userDataRespository)
        {
            userDataRespository = _userDataRespository;
        }

        

        public IQueryable<UserEntity> GetAllUsers()
        {
            return _userDataRespository.GetAllLogins();
        }

        
    }
}