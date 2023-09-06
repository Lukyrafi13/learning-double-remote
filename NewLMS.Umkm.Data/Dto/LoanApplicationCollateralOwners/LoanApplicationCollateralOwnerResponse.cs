using System;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfJob;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfEducation;
using NewLMS.UMKM.Data.Dto.RfMarital;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners
{
    public class LoanApplicationCollateralOwnerResponse : BaseResponse
    {
        public Guid Id { get; set; }

        public string RelationCollateral { get; set; }
        public string OwnerNoIdentity { get; set; }
        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }
        public DateTime OwnerIdentityExpireDate { get; set; }
        public bool OwnerIdentityLifetime { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPlaceOfBirth { get; set; }
        public DateTime? OwnerDateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }
        public int? ResidenceLiveTime { get; set; }
        public string MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string MarriageCertificateIssuer { get; set; }
        public string OwnerEmergencyName { get; set; }
        public string OwnerEmegencyNumber { get; set; }

        public virtual RfParameterDetailResponse RfResidenceStatus { get; set; }
        public virtual RfZipCodeResponse RfZipCode { get; set; }
        public virtual RfJobResponse RfJob { get; set; }
        public virtual RfGenderResponse RfGender { get; set; }
        public virtual RfEducationResponse RfEducation { get; set; }
        public virtual RfMaritalResponse RfMarital { get; set; }
    }
}

