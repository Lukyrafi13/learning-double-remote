using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data
{
    public class DebtorCouple : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(Debtor))]
        [Required]
        [MaxLength(16)]
        public string DebtorCoupleId { get; set; }
        public string DebtorCoupleNoIdentity { get; set; }
		public string Fullname { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool AddressSameWithDebtor { get; set; }
        public string Address { get; set; }
        public RfZipCode RfZipCode { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string NPWP { get; set; }

        public Guid? RfHomestaId {get; set;}
        public Guid? RfEducationId {get; set;}
        public Guid? RfJobId {get; set;}
        public Guid? RfMaritalId {get; set;}

	}
}
