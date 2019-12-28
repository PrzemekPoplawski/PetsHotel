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

        public void SetFirstName (string firstName)
        {
            FirstName = firstName;
        }
        public string FirstName { get; private set; }
    }
}