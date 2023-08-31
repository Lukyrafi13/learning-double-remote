using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data
{
    public class Debtor : BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(16)]
        public string NoIdentity { get; set; }
        
        
        [ForeignKey(nameof(LoanApplication))]
        public Guid? LoanApplicationGuid { get; set; }

		public string Fullname { get; set; }
        [ForeignKey(nameof(RfGender))]
        public Guid RfGenderId { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [ForeignKey(nameof(RfZipCode))]
        public int RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string NPWP { get; set; }
        public string MotherName { get; set; }
        public int? StayDuration { get; set; }
        public int? NumberOfDependents { get; set; }
        [ForeignKey(nameof(RfHomesta))]
        public int? RfHomestaId {get; set;}
        [ForeignKey(nameof(RfEducation))]
        public Guid? RfEducationId {get; set;}
        [ForeignKey(nameof(RfJob))]
        public Guid? RfJobId {get; set;}
        [ForeignKey(nameof(RfMarital))]
        public Guid? RfMaritalId {get; set;}
        public string MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string MarriageCertificateIssuer { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public RfZipCode RfZipCode { get; set; }
        public RfGender RfGender { get; set; }
        public RFJOB RfJob { get; set; }
        public RFEDUCATION RfEducation { get; set; }
        public RFMARITAL RfMarital { get; set; }
        public RfParameterDetail RfHomesta { get; set; }

	}
}
