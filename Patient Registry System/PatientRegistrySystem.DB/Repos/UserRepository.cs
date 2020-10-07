using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PatientRegistrySystem.Services
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(PatientContext context) : base(context)
        {
        }

        public override User AddEntity(User entity)
        {
            return base.AddEntity(entity);
        }

        public override void DeleteEntity(User user)
        {
            using (var context = new PatientContext())
            {
               var  recod= context.Record.FirstOrDefault(u => u.UserID == user.UserId);
                context.Remove(recod);
                context.SaveChanges();
            }
            base.DeleteEntity(user);
        }

        public override IEnumerable<User> FindEntity(Expression<Func<User, bool>> predicate)
        {
            return base.FindEntity(predicate);
        }

        public override IEnumerable<User> GetAll()
        {
            List<User> users;
            using (var context = new PatientContext())
            {
                users = context.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record)
                    .ToList();
            }
            return users;
        }

        public override User GetId(int id)
        {
            User user;
            using (var context = new PatientContext())
            {
                user = context.User
                    .Include(e => e.Employee).Where(u => u.UserId == id)
                    .Include(d => d.Employee)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record)
                    .FirstOrDefault(u => u.UserId == id);
            }
            return user;
        }
        public override void CreateEntity(User entity)
        {
            base.CreateEntity(entity);
            base.SaveChanges();
        }

        public override User UpdateEntity(User entity)
        {
            return base.UpdateEntity(entity);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }


    }
}
