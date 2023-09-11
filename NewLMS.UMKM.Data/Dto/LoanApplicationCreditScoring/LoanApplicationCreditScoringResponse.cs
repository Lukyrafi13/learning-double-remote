using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCreditScoring
{
    public class LoanApplicationCreditScoringResponse : BaseResponse
    {
        public Guid Id { get; set; }
        // Credit Scoring
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
        public int? ScoMonthlyMutationId { get; set; }

        public RfParameterDetailSimpleResponse ScoResidentialReputation { get; set; }
        public RfParameterDetailSimpleResponse ScoMonthlyMutation { get; set; }
        public RfParameterDetailSimpleResponse ScoBankRelation { get; set; }
        public RfParameterDetailSimpleResponse ScoBJBCreditHistory { get; set; }
        public RfParameterDetailSimpleResponse ScoTransacMethod { get; set; }
        public RfParameterDetailSimpleResponse ScoAverageAccBalance { get; set; }
        public RfParameterDetailSimpleResponse ScoNeedLevel { get; set; }
        public RfParameterDetailSimpleResponse ScoFinanceManager { get; set; }
        public RfParameterDetailSimpleResponse ScoBusinesLocation { get; set; }
        public RfParameterDetailSimpleResponse ScoOtherPartyDebt { get; set; }
        public RfParameterDetailSimpleResponse ScoCollateral { get; set; }
    }
}
