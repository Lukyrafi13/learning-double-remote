using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class CompanyLegal : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string EstablishmentDeedNumber { get; set; }
        public DateTime EstablishmentDeedDate { get; set; }
        public string RegisterNumber { get; set; }
        public string NPWP { get; set; }
        public string LatestDeedChange { get; set; }
        public string SIUPNumber { get; set; }
        public DateTime SIUPDate { get; set; }
        public string TDPNumber { get; set; }
        public DateTime TDPDate { get; set; }
        public DateTime TDPDueDate { get; set; }
        public string SKNumber { get; set; }
        public DateTime SKDueDate { get; set; }
        public DateTime DeedDate { get; set; }
        public string SKDPNumber { get; set; }
        public DateTime SKDPNumber { get; set; }
    }
}
