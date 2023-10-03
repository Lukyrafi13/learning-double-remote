using System;
using NewLMS.Umkm.Data.Dto.RfBanks;
using NewLMS.Umkm.Data.Dto.RfSandiBI;
using NewLMS.Umkm.Data.Dto.RfCreditType;
using NewLMS.Umkm.Data.Dto.RfCondition;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory
{
    public class LoanApplicationCreditHistoryResponse : BaseResponse
    {
        public Guid CreditHistoryId { get; set; }
        public string SLIKNoIdentity { get; set; }
        public string DebtorName { get; set; }
        public string BankId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EconomySector { get; set; }
        public string Behaviour { get; set; }
        public string ApplicationType { get; set; }
        public string Condition { get; set; }
        public int PlafondLimit { get; set; }
        public float Interest { get; set; }
        public int Outstanding { get; set; }
        public DateTime? StuckDate { get; set; }
        public bool IsRobo { get; set; }
        public string Collectibility { get; set; }
        public bool SLIKStatus { get; set; }
        public Guid LoanApplicationid { get; set; }
        public string CreditType { get; set; }
        public RfCreditTypeResponse CreditTypeDetail { get; set; }
        public RfBankResponse BankDetail { get; set; }
        public RfSandiBIMinResponse EconomoySectorDetail { get; set; }
        public RfSandiBIMinResponse BehaviourDetail { get; set; }
        public RfSandiBIMinResponse ApplicationTypeDetail { get; set; }
        public RfSandiBIMinResponse CollectibilityDetail { get; set; }
        public RfConditionResponse RfCondition { get; set; }
    }
}
