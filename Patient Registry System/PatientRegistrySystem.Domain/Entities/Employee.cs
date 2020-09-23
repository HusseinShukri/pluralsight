using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(User))]
        [Required(ErrorMessage = "The User is required")]
        public int UserId { get; set; }

        [ForeignKey(nameof(Doctor))]
        [Required(ErrorMessage = "The Superviser Doctor is required")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "The Employee Adress is required")]
        [StringLength(50)]
        public string Adress { get; set; }

        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public List<Record> Record { get; set; } = new List<Record>();
    }
}
