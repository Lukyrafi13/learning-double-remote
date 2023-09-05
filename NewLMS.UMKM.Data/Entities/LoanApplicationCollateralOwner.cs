using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationCollateralOwner : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplicationCollateral))]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(RfRelationCol))]
        public string RelationCollateral { get; set; }
        public string OwnerNoIdentity { get; set; }
        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }

        [ForeignKey(nameof(RfMarital))]
        public string? OwnerMaritalId { get; set; }
        public DateTime OwnerIdentityExpireDate { get; set; }
        public bool OwnerIdentityLifetime { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPlaceOfBirth { get; set; }
        public DateTime? OwnerDateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string MotherName { get; set; }

        [ForeignKey(nameof(RfGender))]
        public string GenderId { get; set; }
        public string Address { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }
        public string PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }

        [ForeignKey(nameof(RfResidenceStatus))]
        public int? ResidenceStatusId { get; set; }
        public int? ResidenceLiveTime { get; set; }

        [ForeignKey(nameof(RfJob))]
        public string? JobCode { get; set; }
        public string MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string MarriageCertificateIssuer { get; set; }
        public string OwnerEmergencyName { get; set; }
        public string OwnerEmegencyNumber { get; set; }


        public virtual LoanApplicationCollateral LoanApplicationCollateral { get; set; }

        public virtual RfParameterDetail RfResidenceStatus { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
        public virtual RfJob RfJob { get; set; }
        public virtual RfGender RfGender { get; set; }
        public virtual RfEducation RfEducation { get; set; }
        public virtual RfMarital RfMarital { get; set; }
        public virtual RfParameterDetail RfHomesta { get; set; }
    }
}

