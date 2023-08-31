using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons
{
    public class LoanApplicationKeyPersonPostRequestDto
    {
                
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
        public Guid? RfEducationId { get; set; }
        public Guid? RfMaritalId { get; set; }
        public string Address { get; set; }
        public int? RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
