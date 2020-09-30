using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.DB.Entities
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
