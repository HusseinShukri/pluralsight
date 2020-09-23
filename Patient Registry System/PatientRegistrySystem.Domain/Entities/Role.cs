using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Role
    {

        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "The Role Name is required")]
        [StringLength(30)]
        public string Name { get; set; }

        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
    }
}
