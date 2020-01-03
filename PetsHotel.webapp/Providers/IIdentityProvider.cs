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
