using PetsHotel.webapp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsHotel.webapp.Service
{
    public interface IUserService
    {
        IQueryable<UserEntity> GetAllUsers();
        void AddUser(UserEntity entity);

    }
}
