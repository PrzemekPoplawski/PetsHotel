using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetsHotel.webapp.Entity;
using PetsHotel.webapp.Models;
using PetsHotel.webapp.Providers;
using PetsHotel.webapp.Repositories;

namespace PetsHotel.webapp.Service
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<LoginEntity> _loginRepository;
        private readonly IIdentityProvider _identityProvider;

        public LoginService(IRepository<LoginEntity> loginRepository,IIdentityProvider identityProvider)
        {
            _loginRepository = loginRepository;
            _identityProvider = identityProvider;
        }


        private static void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public bool Authenticate(string userName, string password)
        {
            var login = GetAllLogins().Where(x => x.UserName == userName).FirstOrDefault();
            
            if(login == null)
            {
                return false;
            }

            if (!VerifyPasswordHash(password, login.PasswordHash, login.PasswordSalt))
            {
                return false;
            }

            //przypisywanie danych do pustego Identity
            var identity = GetIdentity(login.LoginId);
            // wpisywanie uzupełnionego modelu do sesji pod kluczem identity
            _identityProvider.Set("identity", identity);
            
            return true;
        }
        
        private Identity GetIdentity(int loginId)
        {
            var identity = new Identity();
            SetIdentity(identity, loginId);
            
            return identity;
        }

        private void SetIdentity(Identity identity, int loginId)
        {
            var userData = GetAllLogins().Where(p => p.LoginId == loginId).Select(p => new
            {
                Login = p,
                User = p.User_UserId
            }).Select(p=> new
            {
                UserId = p.User.UserId,
                UserName = p.Login.UserName,
                FirstName = p.User.Person_PersonId.FristName
            }).FirstOrDefault();

            identity.SetId(userData.UserId);
            identity.SetUserName(userData.UserName);
        }

        public void CreateLogin(string userName, string password, string email)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            PasswordHash(password, out passwordHash, out passwordSalt);

            var person = new PersonEntity();
            var user = new UserEntity()
            {
                UserTypeId = 2,
                Person_PersonId = person
            };

            var login = new LoginEntity()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserName = userName,
                User_UserId = user
            };
            login.User_UserId.Person_PersonId.Email = email;

            _loginRepository.Add(login);
            _loginRepository.Save();
        }

        public IQueryable<LoginEntity> GetAllLogins()
        {
            return _loginRepository.GetAllValues();
        }

        public void LogOut()
        {
            _identityProvider.Remove("identity");
        }
    }   
}