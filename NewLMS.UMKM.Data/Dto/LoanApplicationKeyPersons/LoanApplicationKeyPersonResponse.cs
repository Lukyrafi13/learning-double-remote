using System;
using NewLMS.UMKM.Data.Dto.RfEducation;
using NewLMS.UMKM.Data.Dto.RfMarital;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons
{
    public class LoanApplicationKeyPersonResponse : BaseResponse
	{
        public Guid Id { get; set; }
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
        public int ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }
        public string MaritalStatusId { get; set; }
        public string EducationId { get; set; }

        public RfEducationResponse RfEducation { get; set; }
        public RfMaritalResponse RfMarital { get; set; }
        public RfZipCodeResponse RfZipCode { get; set; }
    }
}

