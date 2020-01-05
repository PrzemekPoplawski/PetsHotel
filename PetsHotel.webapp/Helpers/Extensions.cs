using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Models;
using PetsHotel.webapp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsHotel.webapp.Helpers
{
    public static class Extensions
    {
        public static Models.Identity IdentityExtension(this HtmlHelper html)
        {
            var identityProvider = new SessionIdentityProvider();

            return identityProvider.Get("identity");

        }

        public static Roles RoleExtension(this HtmlHelper html)
        {
            return new Roles();
        }       
    }
    public class Roles
    {
        private readonly IIdentityProvider _identityProvider;

        public Roles(IIdentityProvider identityProvider = null)
        {
            _identityProvider = identityProvider ?? new SessionIdentityProvider();
        }

        private Identity Identity
        {
            get
            {
                return _identityProvider.Get("identity") ?? new Identity();
            }
        }

        public bool IsAdmin
        {
            get
            {
                return Identity.UserTypeId == (int)UserEntity.UserType.Admin;
            }
        }

        public bool IsUser
        {
            get
            {
                return Identity.UserTypeId == (int)UserEntity.UserType.User;
            }
        }
    }
}