using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    public class User2AnimalEntity
    {
        [Key]
        public int User2AnimalId { get; set; }
        public int AnimalId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("AnimalId")]
        public AnimalEntity Animal_AnimalId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User_UserId { get; set; }

    }
}