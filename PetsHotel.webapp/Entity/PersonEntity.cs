using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    [Table("Person")]
    public class PersonEntity : Entity
    {
        [Key]
        public int PersonId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte SexCode { get; set; }
        public string Address { get; set; }

        public enum SexId
        {
            Male = 0,
            Female = 1
        }
    }
}