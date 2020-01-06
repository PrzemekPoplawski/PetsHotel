using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Animal
{
    public class AddAnimalViewModel
    {
        public int AnimalId { get; set; }
        public int UserId { get; set; }
        [Display(Name ="Data Urodzenia:")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Rodzaj Zwierzaka")]
        public string AnimalType { get; set; }
        [Display(Name = "Nazwa Zwierzaka")]
        public string AnimalName { get; set; }
    }
}