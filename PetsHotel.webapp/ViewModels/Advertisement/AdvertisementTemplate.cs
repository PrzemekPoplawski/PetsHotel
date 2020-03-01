using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Advertisement
{
    public class AdvertisementTemplate
    {
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public AnimalTypes AnimalId { get; set; }
        [Display(Name ="Tytuł")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int AnimalTypeId { get; set; }

        public enum AnimalTypes
        {
            dog=1,
            cat=2,
            other=3 
        }
    }
}