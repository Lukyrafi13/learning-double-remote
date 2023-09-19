using System;
namespace NewLMS.Umkm.Data.Dto.DebtorEmergencies
{
    public class DebtorEmergencyRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }
        public int ZipCodeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}

