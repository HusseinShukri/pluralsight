using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRegistrySystem.Domain.Entities
{
    public class UserRole
    {
        [ForeignKey(nameof(User))]
        [Required(ErrorMessage = "The User Is Required")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Role))]
        [Required(ErrorMessage = "The Role Is Required")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
