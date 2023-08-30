using System;
namespace NewLMS.UMKM.Data.Dto.Debtors
{
    public class DebtorPostRequestDto
    {
        public string NoIdentity { get; set; }
		public string Fullname => FirstName + " " + LastName;
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public Guid RfGenderId { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string NPWP { get; set; }
        public string MotherName { get; set; }
        public int? StayDuration { get; set; }
        public int? NumberOfDependents { get; set; }
        public Guid? RfHomestaId {get; set;}
        public Guid? RfEducationId {get; set;}
        public Guid? RfJobId {get; set;}
        public Guid? RfMaritalId {get; set;}
        public string MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string MarriageCertificateIssuer { get; set; }
    }
}
