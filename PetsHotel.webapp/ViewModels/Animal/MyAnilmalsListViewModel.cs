using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Animal
{
    public class MyAnilmalsListViewModel
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}