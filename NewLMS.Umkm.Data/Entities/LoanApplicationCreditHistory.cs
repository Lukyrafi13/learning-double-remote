using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationCreditHistory : BaseEntity
    {
        [Key]
        [Required]
        public Guid CreditHistoryId { get; set; }

        [MaxLength(16)]
        public string SLIKNoIdentity { get; set; }

        public string DebtorName { get; set; }

        [ForeignKey(nameof(RfBank))]
        public string BankId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(RfSandiBIEconomySectorClass))]
        public string EconomySector { get; set; }

        [ForeignKey(nameof(RfSandiBIBehaviourClass))]
        public string Behaviour { get; set; }

        [ForeignKey(nameof(RfSandiBIApplicationTypeClass))]
        public string ApplicationType { get; set; }

        [ForeignKey(nameof(RfCondition))]
        public string Condition { get; set; }

        public int PlafondLimit { get; set; }

        public float Interest { get; set; }

        public int Outstanding { get; set; }

        public DateTime? StuckDate { get; set; }

        [ForeignKey(nameof(RfSandiBICollectibilityClass))]
        public string Collectibility { get; set; }

        public bool SLIKStatus { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationid { get; set; }


        [ForeignKey(nameof(RfCreditType))]
        public string CreditType { get; set; }

        public bool IsRobo { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfBank RfBank { get; set; }
        public virtual RfCreditType RfCreditType { get; set; }
        public virtual RfSandiBI RfSandiBIEconomySectorClass { get; set; }
        public virtual RfSandiBI RfSandiBIBehaviourClass { get; set; }
        public virtual RfSandiBI RfSandiBIApplicationTypeClass { get; set; }
        public virtual RfSandiBI RfSandiBICollectibilityClass { get; set; }
        public virtual RfCondition RfCondition { get; set; }
    }
}
