using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PetsHotel.webapp.Entity
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=TestDatabase")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        //DependencyInjectionResolver

        public virtual DbSet<UserEntity> UserTable { get; set; }
        public virtual DbSet<PersonEntity> PersonTable { get; set; }
        public virtual DbSet<LoginEntity> LoginTable { get; set; }
        public virtual DbSet<AnimalEntity> AnimalTable { get; set; }
        public virtual DbSet<User2AnimalEntity> User2AnimalTable { get; set; }
    }
}