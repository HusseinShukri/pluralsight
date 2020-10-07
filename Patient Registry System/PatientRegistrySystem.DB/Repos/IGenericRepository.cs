using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatientRegistrySystem.DB.Repos
{
    public  interface IGenericRepository<T> where T : class
    {
        T AddEntity(T entity);
        T UpdateEntity(T entity);
        T GetId(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindEntity(Expression<Func<T, bool>> predicate);
        void CreateEntity(T entity);
        void DeleteEntity(T entity);
        void SaveChanges();
    }
}
