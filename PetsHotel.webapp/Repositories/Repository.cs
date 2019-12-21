using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetsHotel.webapp.Entity;
using System.Data.Entity;

namespace PetsHotel.webapp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity.Entity
    {
        protected DatabaseContext db;
        internal DbSet<TEntity> dbSet;

        public Repository()
        {
            db = new DatabaseContext();
            dbSet = db.Set<TEntity>();
        }
        // Get
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public IQueryable<TEntity> GetAllValues()
        {
            var res = from values in db.
                      select values;
            return res;
                     
        }

        public IQueryable<TEntity> GetValueById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }

    //public class UserRepository
    //{
    //    IQueryable<UserEntity> GetAllUsers()
    //    {
    //        var res = from values in db.UserTable
    //                  select values;
    //        return res;
    //    }
    //}
}