using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners
{
    public class LoanApplicationCollateralOwnerRequest
	{
        public Guid Id { get; set; }
        public string RelationCollateral { get; set; }
        public string OwnerNoIdentity { get; set; }
        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }
        public string? OwnerMaritalId { get; set; }
        public DateTime OwnerIdentityExpireDate { get; set; }
        public bool OwnerIdentityLifetime { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPlaceOfBirth { get; set; }
        public DateTime? OwnerDateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string MotherName { get; set; }
        public string GenderId { get; set; }
        public string Address { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int ZipCodeId { get; set; }
        public string PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }
        public int? ResidenceStatusId { get; set; }
        public int? ResidenceLiveTime { get; set; }
        public string? JobCode { get; set; }
        public string MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string MarriageCertificateIssuer { get; set; }
        public string OwnerEmergencyName { get; set; }
        public string OwnerEmegencyNumber { get; set; }
    }
}

