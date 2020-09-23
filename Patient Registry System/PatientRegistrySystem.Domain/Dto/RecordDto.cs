using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class RecordDto
    {
        [Display(Name = "Patinet")]
        public UserDto UserId { get; set; }

        [Display(Name = "Doctor")]
        public DoctorDto DoctorId { get; set; }

        [Display(Name = "Presciption")]
        public PrescriptionDto PrescriptionId { get; set; }

        [Display(Name = "From Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Patient Case")]
        public string Case { get; set; }

        [Display(Name = "More Information")]
        public string ExtrInfo { get; set; }

        [Display(Name = "Current Status")]
        public int Status { get; set; }

        [Display(Name = "Employee")]
        public EmployeeDto ApprovedBy { get; set; }
    }
}
