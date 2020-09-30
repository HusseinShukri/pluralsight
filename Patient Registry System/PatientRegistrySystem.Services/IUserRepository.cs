using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatientRegistrySystem.Services
{
    public interface IUserRepository
    {
        ActionResult<User> AddEntity(User entity);
        ActionResult<User> UpdateEntity(User entity);
        ActionResult<User> GetId(int id);
        ActionResult<IEnumerable<User>> GetAll();
        ActionResult<IEnumerable<User>> FindEntity(Expression<Func<User, bool>> predicate);
        void DeleteEntity(User entity);
        void SaveChanges();
    }
}
