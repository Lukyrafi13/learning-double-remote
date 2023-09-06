using System;
namespace NewLMS.UMKM.Data.Dto.DebtorCouple
{
    public class DebtorCoupleRequest
    {
        public Guid Id { get; set; }
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string? NPWP { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public bool? IsAddressSameAsDebtor { get; set; }
        public int? ZipCodeId { get; set; }
        public string? JobCode { get; set; }
    }
}

