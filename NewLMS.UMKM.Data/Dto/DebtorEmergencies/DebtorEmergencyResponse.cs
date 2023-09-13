using System;
using NewLMS.UMKM.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.Data.Dto.DebtorEmergencies
{
	public class DebtorEmergencyResponse : BaseResponse
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

        public virtual RfZipCodeResponse RfZipCode { get; set; }
    }
}

