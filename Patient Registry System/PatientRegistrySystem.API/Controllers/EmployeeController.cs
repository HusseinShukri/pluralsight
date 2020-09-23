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

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("Users/{id}/employee")]
    public class EmployeeController : Controller
    {
        private readonly PatientContext context;
        private readonly IMapper mapper;

        public EmployeeController(PatientContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult AllPationInfo(int id) {
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
                if (!user.UserRole.Any(r=>r.Role.Name== "Registration Employee"))
                {
                    return Unauthorized("<<Unauthorized action>>");
                }
                List<Record> records;
                using (var context = new PatientContext())
                {//for autompper its an object not a list of record ****
                    records = context.Record
                        .Include(u => u.User)
                        .Include(d=>d.Doctor)
                        .Include(e=>e.Employee)
                        .Include(p=>p.Prescription)
                        .Where(e=>e.ApprovedBy==user.Employee.FirstOrDefault().EmployeeId)
                        .ToList();
                }
                return Ok(mapper.Map<RecordDto[]>(records));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Something realy bad happened");
            }
        }
    }
}
