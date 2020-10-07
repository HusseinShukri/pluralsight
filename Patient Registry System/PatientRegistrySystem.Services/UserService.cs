using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Linq;

namespace PatientRegistrySystem.Services
{
    public class UserService : Controller, IUserService
    {
        public IMapper Mapper { get; }
        public IGenericRepository<User> userRepository { get; }

        public UserService(IMapper mapper, IGenericRepository<User> UserGenericRepository)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            userRepository = UserGenericRepository ?? throw new ArgumentNullException(nameof(UserGenericRepository));
        }
        //CreateUser/UpdateUser/DeleteUser/GetUser/GetAllUsers

        public IActionResult GetAllUsers()
        {
            var usersFromRepo = userRepository.GetAll();
            var DtoUsers = Mapper.Map<UserDto[]>(usersFromRepo);
            if (!usersFromRepo.Any()) { return NotFound(); }
            return Ok(DtoUsers);
        }

        public IActionResult GetUser(int id)
        {
            var usersFromRepo = userRepository.GetId(id);
            var DtoUsers = Mapper.Map<UserDto>(usersFromRepo);
            if (usersFromRepo == null) { return NotFound(); }
            return Ok(DtoUsers);
        }

        public IActionResult UpdateUser(int id, User user)
        {
            if (user == null) { return NotFound(); }
            User usersFromRepo;
            using (PatientContext context = new PatientContext())
            {
                usersFromRepo = context.User.Find(id);
            }
            //var DtoUsers = Mapper.Map<UserDto>(usersFromRepo);
            if (usersFromRepo == null) { return NotFound(); }
            userRepository.UpdateEntity(user);
            userRepository.SaveChanges();

            return NoContent();
        }

        public IActionResult CreateUser(UserDto user)
        {
            if (user == null) { return NotFound(); }
            var userEntity = Mapper.Map<User>(user);
            userRepository.CreateEntity(userEntity);
            return RedirectToAction("GrtUser", "Users", new { @id = userEntity.UserId }); ;
        }

        public IActionResult DeleteUser(User user)
        {
            if (user == null) { return NotFound(); }
            userRepository.DeleteEntity(user);
            return NoContent();
        }
    }
}
