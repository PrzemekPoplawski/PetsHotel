using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    [Table("Advertisement")]
    public class AdvertisementEntity : Entity
    {
        [Key]
        public int AdvertisementId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public int AnimalTypeId { get; set; }
        public byte[] PhotoConversion { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User_UserId { get; set; }

        enum AnimalTypes
        {
            dog=1,
            cat=2,
            other=3
        }
    }
}