using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatientRegistrySystem.Services
{
    public  interface IGenericRepository<T> where T : class
    {
        ActionResult<T> AddEntity(T entity);
        ActionResult<T> UpdateEntity(T entity);
        ActionResult<T> GetId(int id);
        ActionResult<IEnumerable<T>> GetAll();
        ActionResult<IEnumerable<T>> FindEntity(Expression<Func<T, bool>> predicate);
        ActionResult<T> DeleteEntity(int id);
        void SaveChanges();
    }
}
