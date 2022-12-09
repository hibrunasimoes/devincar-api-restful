using System;
using DEVinCar.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, Tkey> where TEntity : class
    {
        protected readonly DevInCarDbContext _context;

        public BaseRepository(DevInCarDbContext context)
        {
            _context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual TEntity GetById(Tkey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

        }

        public virtual int GetTotal()
        {
            return _context.Set<TEntity>().Count();
        }

        public virtual IList<TEntity> ListAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
