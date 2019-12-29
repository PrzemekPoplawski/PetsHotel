using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    [Table("User")]
    public class UserEntity : Entity
    {
        [Key]
        public int UserId { get; set; }
        public string UserStatus { get; set; }
        public int UserTypeId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person_PersonId { get; set; }

        public enum UserType
        {
            User = 2,
            Admin = 3
            
        }
    }
}