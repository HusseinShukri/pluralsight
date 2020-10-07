using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientRegistrySystem.Services
{
    public interface IUserService
    {
        IActionResult GetAllUsers();
        IActionResult GetUser(int id);
        IActionResult UpdateUser(int id ,User user);
        IActionResult CreateUser(UserDto user);
        IActionResult DeleteUser(User user);
    }
}
