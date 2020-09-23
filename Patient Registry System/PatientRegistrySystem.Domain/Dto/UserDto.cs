using System.Collections.Generic;

namespace PatientRegistrySystem.Domain.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<EmployeeDto> Employee { get; set; } = new List<EmployeeDto>();
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
