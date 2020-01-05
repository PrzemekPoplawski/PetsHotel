using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PetsHotel.webapp.ViewModels.UserData
{
    public class EditViewModel
    {
        public int PersonId { get; set; }
        [Display(Name = "Login:")]
        public string Login { get; set; }
        [Display(Name = "Imię:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string LastName { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Email { get; set; }
        [Display(Name = "Telefon:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string SexCode { get; set; }
        [Display(Name = "Adres:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Address { get; set; }
        [Display(Name = "Rola")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Role { get; set; }

        public IEnumerable<SelectListItem> Roles
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value = "2", Text = "User"},
                    new SelectListItem{Value = "3", Text = "Admin"}
                };
            }
        }
        public IEnumerable<SelectListItem> SexOptions {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Value = "1", Text = "Mężczyzna"},
                    new SelectListItem{ Value = "2", Text = "Kobieta"}
                };
            } }

    }

}