using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationKeyPerson : BaseEntity
    {
        public Guid Id { get; set; }        
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
        [ForeignKey("RFEducationId")]
        public Guid? RfEducationId { get; set; }
        [ForeignKey("RFMaritalId")]
        public Guid? RfMaritalId { get; set; }
        public string Address { get; set; }
        [ForeignKey("RfZipCodeId")]
        public Guid? RfZipCode { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int? RfZipCodeId { get; set; }

        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
    }
}