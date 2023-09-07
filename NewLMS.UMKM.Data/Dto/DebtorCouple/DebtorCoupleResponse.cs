using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Dto.RfJob;

namespace NewLMS.UMKM.Data.Dto.DebtorCouple
{
    public class DebtorCoupleResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string? NPWP { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool AddressSameAsDebtor { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? ZipCodeId { get; set; }
        public string? JobCode { get; set; }

        public RfZipCodeResponse RfZipCode { get; set; }
        public RfJobSimpleResponse RfJob { get; set; }
    }
}
