using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsHotel.webapp.Models
{
    public class Identity
    {
        public void SetUserId(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; private set; }

        public void SetLoginId(int loginId)
        {
            LoginId = loginId;
        }
        public int LoginId { get; private set; }

        public void SetPersonId(int personId)
        {
            PersonId = personId;
        }
        public int PersonId { get; private set; }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; private set; }

        public void SetUserTypeId(int userTypeId)
        {
            UserTypeId = userTypeId;
        }
        public int UserTypeId { get; private set; }

        public void SetFirstName (string firstName)
        {
            FirstName = firstName;
        }
        public string FirstName { get; private set; }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }
        public string LastName { get; private set; }

        
    }
}