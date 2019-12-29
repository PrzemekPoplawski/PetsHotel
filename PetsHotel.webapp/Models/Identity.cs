using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Models
{
    public class Identity
    {
        public void SetId(int id)
        {
            ID = id;
        }
        public int ID { get; private set; }

        public void SetUserName (string userName)
        {
            UserName = userName;
        }
        public string UserName { get; private set; }

        public int UserTypeId { get; private set; }

        public void SetUserTypeId(int userTypeId)
        {
            UserTypeId = userTypeId;
        }
    }
}