using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsHotel.webapp.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity.Entity
    {
        IQueryable<TEntity> GetAllValues();
        IQueryable<TEntity> GetValueById(int id);
        void Add(TEntity entity);
        void Save();
    }
}
