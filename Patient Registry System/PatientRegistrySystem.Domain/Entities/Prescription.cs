using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.Domain.Entities
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [MaxLength(200)]
        public string LabTest { get; set; }

        public List<Medicine> Medicines { get; set; }

        [MaxLength(500)]
        public string ExtraInformation { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy }")]
        public DateTime ExpiryDate { get; set; }

        public List<Record> Record { get; set; } = new List<Record>();
    }
}
