using PatientRegistrySystem.DB.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientRegistrySystem.DB.Repos
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public PatientContext _context { get; }
        protected GenericRepository(PatientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual T AddEntity(T entity)
        {
              return _context.Add(entity).Entity;
        }

        public virtual void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> FindEntity(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable().ToList();
        }

        public virtual T GetId(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual T UpdateEntity(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual void CreateEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
