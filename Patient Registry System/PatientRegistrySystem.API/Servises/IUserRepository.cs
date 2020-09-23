using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PatientRegistrySystem.API.Servises
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
