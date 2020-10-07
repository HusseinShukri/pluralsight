using System;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public IUserService _userService { get; }

        //CreateUser/UpdateUser/DeleteUser/GetUser/GetAllUsers
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        [HttpGet("{id:int}")]
        public IActionResult GrtUser(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            return _userService.UpdateUser(id, user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            return _userService.CreateUser(user);
        }
        [HttpDelete]
        public IActionResult DeleteUser([FromBody]User user)
        {
            return _userService.DeleteUser(user);
        }
    }
}
