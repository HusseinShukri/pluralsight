using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.DB.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The FirstName is required")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The LastName is required")]
        public string LastName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The Login is required")]
        public string Login { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Phone is required")]
        [StringLength(15)]
        public string Phone { get; set; }


        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
        public List<Record> Record { get; set; } = new List<Record>();
        public List<Employee> Employee { get; set; } = new List<Employee>();
        public List<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}
