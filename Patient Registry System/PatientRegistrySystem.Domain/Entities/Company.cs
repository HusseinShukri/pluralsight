using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The Company Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
       
        [Required(ErrorMessage ="The Company Adderss is required")]
        [StringLength(50)]
        public string Address { get; set; }

        public List<Medicine> Medicine { get; set; } = new List<Medicine>();
    }
}
