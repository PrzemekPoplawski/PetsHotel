﻿using PetsHotel.webapp.Entity;
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


        public class Roles
        {
            private readonly SessionIdentityProvider _identityProvider;

            public Roles()
            {
                var sessionIdentityProvider = new SessionIdentityProvider();
                _identityProvider = sessionIdentityProvider;
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
}