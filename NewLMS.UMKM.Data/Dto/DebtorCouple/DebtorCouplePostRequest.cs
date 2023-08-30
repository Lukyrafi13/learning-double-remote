using System;
namespace NewLMS.UMKM.Data.Dto.DebtorCouples
{
    public class DebtorCouplePostRequestDto
    {
        public string DebtorCoupleId { get; set; }
        public string DebtorCoupleNoIdentity { get; set; }
		public string Fullname { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool AddressSameWithDebtor { get; set; }
        public string Address { get; set; }
        public int? RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string NPWP { get; set; }

        public Guid? RfJobId {get; set;}
    }
}
