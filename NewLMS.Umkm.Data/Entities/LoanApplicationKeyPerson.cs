using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationKeyPerson : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public string NoIdentity { get; set; }
        public DateTime? IdentityDueDate { get; set; }
        public bool LifetimeIdentity { get; set; } = false;
        public string? NPWP { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(RfMarital))]
        public string MaritalStatusId { get; set; }

        [ForeignKey(nameof(RfEducation))]
        public string EducationId { get; set; }


        public virtual RfEducation RfEducation { get; set; }
        public virtual RfMarital RfMarital { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}
