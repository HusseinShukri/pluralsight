using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientRegistrySystem.DB.Repos
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PatientContext context;

        protected GenericRepository(PatientContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ActionResult<T> AddEntity(T entity)
        {
            return context.Add(entity).Entity;
        }

        public ActionResult<IEnumerable<T>> FindEntity(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public ActionResult<IEnumerable<T>> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public ActionResult<T> GetId(int id)
        {
            return context.Find<T>(id);
        }
        
        public ActionResult<T> UpdateEntity(T entity)
        {
            return context.Update(entity).Entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public ActionResult<T> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
