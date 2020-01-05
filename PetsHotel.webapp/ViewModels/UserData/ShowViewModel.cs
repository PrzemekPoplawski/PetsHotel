using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.ViewModels.UserData
{
    public class ShowViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LoginId { get; set; }
        public string Role { get; set; }

        public List<SelectListItem> Roles
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Value="2", Text="User"},
                    new SelectListItem{ Value="3", Text="Admin"}
                };
            }
        }
    }
}