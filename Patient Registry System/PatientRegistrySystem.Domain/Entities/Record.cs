using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        [Required(ErrorMessage = "The Pationt user is required")]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The Doctor user is required")]
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(Prescription))]
        public int? PrescriptionId { get; set; }

        [Required(ErrorMessage = "The StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The EndDate is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "The Case is required")]
        [MaxLength(500)]
        public string Case { get; set; }

        [MaxLength(500)]
        public string ExtrInfo { get; set; }

        [Required(ErrorMessage = "The Current Status is required")]
        public int Status { get; set; }

        [Required(ErrorMessage = "The Approved By Employee is required")]
        [ForeignKey(nameof(Employee))]
        public int ApprovedBy { get; set; }

        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public Prescription Prescription { get; set; }
        public Employee Employee { get; set; }
    }
}
