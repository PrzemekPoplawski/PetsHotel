using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    public class AnimalEntity
    {
        [Key]
        public int AnimalId { get; set; }
        public string AnimalType { get; set; }
        public DateTime DataOfBirth { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User_UserId { get; set; }
    }
}