using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPostRequest
    {
    }

    public class LoanApplicationIDEPostRequest : LoanApplicationGetDetailTabRequest
    {
        public LoanApplicationInitialDataEntryRequest InitialData { get; set; }
        public LoanApplicationCreditScoringPostRequest CreditScoring { get; set; }
    }

    public class LoanApplicationInitialDataEntryRequest
    {
        public string ProductId { get; set; }
        public int OwnerCategoryId { get; set; }
        public bool? IsBusinessCycle { get; set; }
        public int? BusinessCycleId { get; set; }
        public int? BusinessCycleMonth { get; set; }
        public string BookingBranchId { get; set; }
    }

    public class LoanApplicationCreditScoringPostRequest
    {
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
    }
}
