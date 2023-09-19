namespace NewLMS.Umkm.Data.Dto.LoanApplicationCreditScorings
{
    public class LoanApplicationCreditScoringRequest
    {
        public int? ScoResidentialReputationId { get; set; }
        public int? ScoMonthlyMutationId { get; set; }
        public int? ScoBankRelationId { get; set; }
        public int? ScoBJBCreditHistoryId { get; set; }
        public int? ScoTransacMethodId { get; set; }
        public int? ScoAverageAccBalanceId { get; set; }
        public int? ScoNeedLevelId { get; set; }
        public int? ScoFinanceManagerId { get; set; }
        public int? ScoBusinesLocationId { get; set; }
        public int? ScoOtherPartyDebtId { get; set; }
        public int? ScoCollateralId { get; set; }
    }
}

