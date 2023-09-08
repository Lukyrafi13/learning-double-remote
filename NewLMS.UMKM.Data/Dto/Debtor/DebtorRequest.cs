using System;
namespace NewLMS.UMKM.Data.Dto.Debtor
{
    public class DebtorRequest
    {
        public Guid Id { get; set; }
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string? NPWP { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string? MotherName { get; set; }
        public string? GenderId { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }
        public int? ResidenceStatusId { get; set; }
        public int? ResidenceLiveTime { get; set; }
        public string? EducationId { get; set; }
        public string? MaritalStatusId { get; set; }
        public string? JobCode { get; set; }
        public string? MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string? MarriageCertificateIssuer { get; set; }
    }
}

