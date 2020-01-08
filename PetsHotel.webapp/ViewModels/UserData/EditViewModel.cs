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
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Nie prawidłowy numer telefonu")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public byte SexCode { get; set; }
        [Display(Name = "Adres:")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public string Address { get; set; }
        [Display(Name = "Rola")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        public int RoleId { get; set; }

        public IEnumerable<SelectListItem> Roles
        {
            get
            {
                return new SelectList(new Dictionary<int, string> { { 2, "User" }, { 3, "Admin" } }, "Key", "Value");
            }
        }
        public IEnumerable<SelectListItem> SexOptions
        {
            get
            {
                return new SelectList(new Dictionary<byte, string> {{ 1, "Mężyczyzna" },{ 2, "Kobieta" }}, "Key", "Value");
            }
        }
    }
}