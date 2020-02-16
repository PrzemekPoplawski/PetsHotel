using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.ViewModels.UserData
{
    public class ShowViewModel
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Login")]
        public string UserName { get; set; }
        [Display(Name = "Person Id")]
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        [Display(Name="Rola")]
        public string Role
        {
            get
            {
                var roles = new Dictionary<int, string> { { 2, "User" }, { 3, "Admin" } };
                roles.TryGetValue(RoleId, out string role);
                return role;
            }
        }
    }
}