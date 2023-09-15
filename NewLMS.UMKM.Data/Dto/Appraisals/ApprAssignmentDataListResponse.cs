using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApprAssignmentDataListResponse
    {
        public Guid LoanApplicationGuid { get; set; }
        public Guid DebtorGuid { get; set; }
        public Guid LoanApplicationCollateralGuid { get; set; }
        public string LoanApplicationId { get; set; }
        public string DebtorName { get; set; }
        public string CompanyName { get; set; }
        public string CreditSubProduct { get; set; }
        public string Collateral { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
