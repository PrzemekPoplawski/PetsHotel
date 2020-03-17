using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.ViewModels.Advertisement
{
    public class AdvertisementTemplate
    {
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        [Display(Name ="Tytuł:")]
        [Required(ErrorMessage ="To pole jest wymagane")]
        public string Title { get; set; }
        [Display(Name ="Opis:")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Description { get; set; }
        [Display(Name ="Adres:")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Adress { get; set; }
        [Display(Name ="Numer telefonu:")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Podany numer telefon jest nie poprawny")]
        public long PhoneNumber { get; set; }
        [Display(Name ="Od kiedy:")]
        [Required(ErrorMessage =("To pole jest wymagane"))]
        public DateTime ValidFrom { get; set; }
        [Display(Name ="Do kiedy:")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public DateTime ValidTo { get; set; }
        public int AnimalTypeId { get; set; }
        public HttpPostedFileBase FileUpload { get; set; }
        public byte[] bytePhoto { get; set; }
        public Image PhotoFromBytes { get; set; }

        public IEnumerable<SelectListItem> AnimalTypes
        {
            get
            {
                return new List<SelectListItem>(){ new SelectListItem() { Text = "Dog", Value = "1" } };
            }
        }
    }
}