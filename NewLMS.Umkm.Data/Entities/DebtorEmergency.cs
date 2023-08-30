using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data
{
    public class DebtorEmergency : BaseEntity
    {
        
        [Key]
        [Required]
        public Guid DebtorEmergencyId { get; set; }

        public string Fullname { get; set; }
        public string NoIdentityEmergency { get; set; }
        public string Phone { get; set; }
        public string NPWP { get; set; }
        public string Address { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        [MaxLength(16)]
        [ForeignKey(nameof(Debtor))]
        public string DebtorId { get; set; }

	}
}
