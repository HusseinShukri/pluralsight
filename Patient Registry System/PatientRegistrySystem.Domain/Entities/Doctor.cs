using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(User))]
        [Required(ErrorMessage = "The User is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Adress is required")]
        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        public User User { get; set; }
        public List<Record> Record { get; set; } = new List<Record>();
    }
}
