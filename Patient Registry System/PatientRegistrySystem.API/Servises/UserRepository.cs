using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.Data;
using PatientRegistrySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientRegistrySystem.API.Servises
{
    public class UserRepository 
    {
        private readonly PatientContext _context;

        public UserRepository(PatientContext patientContext)
        {
            this._context = patientContext;
        }

        public ActionResult<User> AddEntity(User entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.User.Add(entity);
            return (entity);
        }

        public IActionResult DeleteEntity(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindEntity(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
      
        public IEnumerable<User> GetAll()
        {
            List<User> users;
            using (var context = new PatientContext())
            {
                users = context.User.Include(e => e.Employee).Include(u => u.UserRole).ThenInclude(r => r.Role).ToList();
            }
            return users;
        }

        public ActionResult<User> GetId(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public ActionResult<User> UpdateEntity(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
