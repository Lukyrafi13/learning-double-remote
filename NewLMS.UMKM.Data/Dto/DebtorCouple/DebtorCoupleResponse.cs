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
using NewLMS.UMKM.Data.Dto.RfMarital;

namespace NewLMS.UMKM.Data.Dto.DebtorCouple
{
    public class DebtorCoupleResponse
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

        public virtual RfZipCodeResponse RfZipCode { get; set; }
        public virtual RfJobResponse RfJob { get; set; }
        public virtual RfMaritalResponse RfMarital { get; set; }
    }
}

