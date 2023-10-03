using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory
{
    public class LoanApplicationCreditHistoryPostRequest
    {
        public string SLIKNoIdentity { get; set; }

        public string DebtorName { get; set; }

        public string BankId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EconomySector { get; set; }

        public string Behaviour { get; set; }

        public string ApplicationType { get; set; }

        public string Condition { get; set; }

        public int PlafondLimit { get; set; }

        public float Interest { get; set; }

        public int Outstanding { get; set; }

        public DateTime StuckDate { get; set; }

        public string Collectibility { get; set; }

        public bool SLIKStatus { get; set; }
        public string CreditType { get; set; }

       // public bool IsRobo { get; set; }

        public Guid LoanApplicationid { get; set; }
    }
}
