using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Entity
{
    [Table("Login")]
    public class LoginEntity : Entity
    {
        [Key]
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User_UserId { get; set; }

    
    }
}