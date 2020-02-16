using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.ViewModels.Animal
{
    public class TestAnimalListcs
    {
        public string AnimalName { get; set; }

        public static IEnumerable<TestAnimalListcs> AnimalList()
        {
            var animal = new List<TestAnimalListcs>
            {
                new TestAnimalListcs(){ AnimalName = "Zenek"},
                new TestAnimalListcs(){ AnimalName = "Baka"},
                new TestAnimalListcs(){ AnimalName = "Wiesiek"},
                new TestAnimalListcs(){ AnimalName = "Azor"},
            };

            return animal;
        }
    }
}