using System;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Dto
{
    public class RecordDto
    {
        [Display(Name = "Patinet name")]
        public string PatinetName { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        //[Display(Name = "Presciption")]
        //public PrescriptionDto Prescription { get; set; }

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

        [Display(Name = "Approved By Emolyee")]
        public string ApprovedBy { get; set; }
    }
}
