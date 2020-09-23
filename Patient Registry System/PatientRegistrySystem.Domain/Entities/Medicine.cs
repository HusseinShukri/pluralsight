using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PatientRegistrySystem.Domain.Entities
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Yhe Medicine Name is required")]
        [StringLength(30)]
        public String Name { get; set; }

        [ForeignKey(nameof(Company))]
        [Required(ErrorMessage = "The Company is required")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public Prescription Prescription { get; set; }
    }
}
