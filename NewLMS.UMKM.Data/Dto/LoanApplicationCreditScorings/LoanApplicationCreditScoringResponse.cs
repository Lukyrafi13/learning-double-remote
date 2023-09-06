using System;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCreditScorings
{
    public class LoanApplicationCreditScoringResponse
	{
        public Guid Id { get; set; }
        public int ScoResidentialReputationId { get; set; }
        public int ScoBankRelationId { get; set; }
        public int ScoBJBCreditHistoryId { get; set; }
        public int ScoTransacMethodId { get; set; }
        public int ScoAverageAccBalanceId { get; set; }
        public int ScoNeedLevelId { get; set; }
        public int ScoFinanceManagerId { get; set; }
        public int ScoBusinesLocationId { get; set; }
        public int ScoOtherPartyDebtId { get; set; }
        public int ScoCollateralId { get; set; }

        public RfParameterDetailResponse ScoResidentialReputation { get; set; }
        public RfParameterDetailResponse ScoBankRelation { get; set; }
        public RfParameterDetailResponse ScoBJBCreditHistory { get; set; }
        public RfParameterDetailResponse ScoTransacMethod { get; set; }
        public RfParameterDetailResponse ScoAverageAccBalance { get; set; }
        public RfParameterDetailResponse ScoNeedLevel { get; set; }
        public RfParameterDetailResponse ScoFinanceManager { get; set; }
        public RfParameterDetailResponse ScoBusinesLocation { get; set; }
        public RfParameterDetailResponse ScoOtherPartyDebt { get; set; }
        public RfParameterDetailResponse ScoCollateral { get; set; }
    }
}

