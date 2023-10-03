using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory
{
    public class LoanApplicationCreditHistoryPutRequest : LoanApplicationCreditHistoryPostRequest
    {
        public Guid CreditHistoryId { get; set; }
    }
}
