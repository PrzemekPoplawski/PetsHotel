using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetsHotel.webapp.Models;

namespace PetsHotel.webapp.Providers
{
    public class SessionIdentityProvider : IIdentityProvider
    {
        public Identity Get(string key)
        {
            var valueFromSession = HttpContext.Current.Session[key];
            if(valueFromSession is Identity)
            {
                return (Identity) valueFromSession;
            }
            return default;
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public void Set(string key, Identity identity)
        {
            //"identity"
            HttpContext.Current.Session[key] = identity;
        }
    }
}