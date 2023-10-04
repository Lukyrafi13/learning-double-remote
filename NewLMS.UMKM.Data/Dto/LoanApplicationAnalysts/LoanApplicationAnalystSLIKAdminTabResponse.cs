using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts
{
    public class LoanApplicationAnalystSLIKAdminTabResponse
    {
        public List<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }
        public List<LoanApplicationCreditHistoryResponse> CreditHistories { get; set; }
    }
}
