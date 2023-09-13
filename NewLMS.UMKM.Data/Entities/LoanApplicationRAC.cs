using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationRAC : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey(nameof(LoanApplication))]
        public Guid Id { get; set; }
        
        public bool? MinimumAge { get; set; }
        public bool? MaximumAge { get; set; }
        public bool? IdentityCard { get; set; }
        public bool? NationalBlacklist { get; set; }
        public bool? BICollectibility { get; set; }
        public bool? NotCollectibility { get; set; }
        public bool? HasAge { get; set; }
        public bool? HasNoCreditFacilities { get; set; }
        public bool? NeverReceivedCredit { get; set; }
        public bool? BPJSTKParticipants { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
    }
}
