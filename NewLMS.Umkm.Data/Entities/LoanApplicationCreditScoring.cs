using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationCreditScoring : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplication))]
        [Required]
        public Guid Id { get; set; }

        // Credit Scoring
        [ForeignKey(nameof(ScoResidentialReputation))]
        public int ScoResidentialReputationId { get; set; }

        [ForeignKey(nameof(ScoBankRelation))]
        public int ScoBankRelationId { get; set; }

        [ForeignKey(nameof(ScoBJBCreditHistory))]
        public int ScoBJBCreditHistoryId { get; set; }

        [ForeignKey(nameof(ScoTransacMethod))]
        public int ScoTransacMethodId { get; set; }

        [ForeignKey(nameof(ScoAverageAccBalance))]
        public int ScoAverageAccBalanceId { get; set; }

        [ForeignKey(nameof(ScoNeedLevel))]
        public int ScoNeedLevelId { get; set; }

        [ForeignKey(nameof(ScoFinanceManager))]
        public int ScoFinanceManagerId { get; set; }

        [ForeignKey(nameof(ScoBusinesLocation))]
        public int ScoBusinesLocationId { get; set; }

        [ForeignKey(nameof(ScoOtherPartyDebt))]
        public int ScoOtherPartyDebtId { get; set; }

        [ForeignKey(nameof(ScoCollateral))]
        public int ScoCollateralId { get; set; }

        [ForeignKey(nameof(ScoMonthlyMutation))]
        public int? ScoMonthlyMutationId { get; set; }

        public virtual LoanApplication LoanApplication { get; set;}

        public virtual RfParameterDetail ScoResidentialReputation { get; set; }
        public virtual RfParameterDetail ScoMonthlyMutation { get; set; }
        public virtual RfParameterDetail ScoBankRelation { get; set; }
        public virtual RfParameterDetail ScoBJBCreditHistory { get; set; }
        public virtual RfParameterDetail ScoTransacMethod { get; set; }
        public virtual RfParameterDetail ScoAverageAccBalance { get; set; }
        public virtual RfParameterDetail ScoNeedLevel { get; set; }
        public virtual RfParameterDetail ScoFinanceManager { get; set; }
        public virtual RfParameterDetail ScoBusinesLocation { get; set; }
        public virtual RfParameterDetail ScoOtherPartyDebt { get; set; }
        public virtual RfParameterDetail ScoCollateral { get; set; }
    }
}