using PetsHotel.webapp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Service
{
    public interface ILoginService
    {
        void CreateLogin(string userName, string password, string email);

        bool Authenticate(string userName, string password);

        IQueryable<LoginEntity> GetAllLogins();

        void LogOut();
    }
}