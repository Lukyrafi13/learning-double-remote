using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Entities
{
    public class Debtor : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [MaxLength(16)]
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }

        public string? NPWP { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string? MotherName { get; set; }

        [ForeignKey(nameof(RfGender))]
        public string? GenderId { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int? ZipCodeId { get; set; }

        public string? PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }

        [ForeignKey(nameof(RfResidenceStatus))]
        public int? ResidenceStatusId { get; set; }
        public int? ResidenceLiveTime { get; set; }

        [ForeignKey(nameof(RfEducation))]
        public string? EducationId { get; set; }

        [ForeignKey(nameof(RfMarital))]
        public string? MaritalStatusId { get; set; }

        [ForeignKey(nameof(RfJob))]
        public string? JobCode { get; set; }
        public string? MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string? MarriageCertificateIssuer { get; set; }
        public virtual RfParameterDetail RfResidenceStatus { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
        public virtual RfJob RfJob { get; set; }
        public virtual RfGender RfGender { get; set; }
        public virtual RfEducation RfEducation { get; set; }
        public virtual RfMarital RfMarital { get; set; }
        public virtual RfParameterDetail RfHomesta { get; set; }


    }
}

