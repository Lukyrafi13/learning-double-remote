using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data
{
    public class CompanyEntity : BaseEntity
    {
        [Key]
        [Required]
        public string NoIdentity { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }
        public string Address { get; set; }
        public Guid RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        
        // Contact Person
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }        public string ContactPersonAddress { get; set; }
        public Guid RfContactPersonZipCodeId { get; set; }
        public string ContactPersonNeighborhoods { get; set; }
        public string ContactPersonDistrict { get; set; }
        public string ContactPersonCity { get; set; }
        public string ContactPersonProvince { get; set; }
        
        // Legality
        public string DeedOfEstablishmentNumber { get; set; }
        public DateTime? DeedOfEstablishmentDate { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? SKDate { get; set; }
        public string LatestDeedOfChanges { get; set; }
        public DateTime? DeedDate { get; set; }
        public string SIUPNumber { get; set; }
        public DateTime? SIUPDate { get; set; }
        public string TDPNumber { get; set; }
        public DateTime? TDPExpiryDate { get; set; }
        public DateTime? TDPDate { get; set; }
        public string SKDPNumber { get; set; }
        public DateTime? SKDPExpiryDate { get; set; }
        public DateTime? SKDPDate { get; set; }



	}
}
