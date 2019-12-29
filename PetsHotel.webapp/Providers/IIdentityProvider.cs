using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsHotel.webapp.Models;

namespace PetsHotel.webapp.Providers
{
    public interface IIdentityProvider
    {
        Identity Get(string key);
        void Set(string key, Identity identity);
        void Remove(string key);
    }
}
