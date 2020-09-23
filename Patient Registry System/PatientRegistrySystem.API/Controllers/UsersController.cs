using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.Domain.Entities;
using AutoMapper;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PatientRegistrySystem.API.Servises;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly PatientContext patientContext;
        private readonly IMapper mapper;
        private readonly UserRepository userRepository;

        public UsersController(PatientContext patientContext, IMapper mapper, UserRepository userRepository)
        {
            this.patientContext = patientContext ?? throw new ArgumentNullException(nameof(patientContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public ActionResult<UserDto[]> GetAllUsers()
        {
            List<User> users;
            using (var context = new PatientContext())
            {
                users = context.User.Include(e => e.Employee).Include(u => u.UserRole).ThenInclude(r => r.Role).ToList();
            }
            if (!users.Any()) return NotFound();
            return mapper.Map<UserDto[]>(users);
        }
        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            try
            {
                User user;
                using (var context = new PatientContext())
                {
                    user = context.User
                        .Include(e => e.Employee)
                        .Include(u => u.UserRole).ThenInclude(r => r.Role)
                        .FirstOrDefault(u => u.UserId == id);
                }
                if (user == null)
                {
                    return NotFound("<< No such user >>");
                }

                return Ok(mapper.Map<UserDto>(user));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something realy bad happened");
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id ) {

            User user = patientContext.User.Find(id);
            if (user==null) {
                return NotFound("<< No such user >>");
            }
            patientContext.Remove(user);
            patientContext.SaveChanges();
            return NoContent();
        }
    
    }
}
