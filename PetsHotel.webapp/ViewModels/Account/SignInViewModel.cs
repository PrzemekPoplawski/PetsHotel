using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Account
{
    public class SignInViewModel
    {
        [Display(Name = "Login lub Email:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Login { get; set; }
        [Display(Name = "Hasło: ")]
        public string Password { get; set; }
    }
}