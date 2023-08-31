using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationKeyPerson : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        public string Fullname { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JobPosition { get; set; }
        public string NoIdentity { get; set; }
        public string Phone { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifeTime { get; set; }
        public string NPWP { get; set; }
        [ForeignKey(nameof(RfEducation))]
        public Guid? RfEducationId { get; set; }
        [ForeignKey(nameof(RfMarital))]
        public Guid? RfMaritalId { get; set; }
        public string Address { get; set; }
        [ForeignKey(nameof(RfZipCode))]
        public int? RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        
        public LoanApplication LoanApplication { get; set; }
        public RFEDUCATION RfEducation { get; set; }
        public RFMARITAL RfMarital { get; set; }
        public RfZipCode RfZipCode { get; set; }
    }
}