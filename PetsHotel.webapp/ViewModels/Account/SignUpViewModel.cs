using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Account
{
    public class SignUpViewModel
    {
        
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Email { get; set; }
        [Display(Name = "Login:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Login { get; set; }
        [Display(Name = "Hasło: ")]
        [Required]
        [MinLength(6,ErrorMessage = "Hasło musi być dłuższe niż 6 znaków")]
        public string Password { get; set; }
        [Display(Name = "Potwierdz hasło: ")]
        [Required(ErrorMessage = "Pole {0} jest wymagane"),]
        [Compare("Password", ErrorMessage = "Hasło się nie zgadza")]        
        public string ConfirmPassword { get; set; }
    }
}