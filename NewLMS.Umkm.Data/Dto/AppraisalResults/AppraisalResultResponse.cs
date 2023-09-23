using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalResults
{
    public class AppraisalResultResponse
    {
        public List<AppraisalResultCollateralAppraisalResponse> CollateralAppraisalList { get; set; }
        public List<AppraisalResultCollateralBindingResponse> CollateralBindingList { get; set; }
        public List<AppraisalResultCollateralCoverageFixedResponse> CollateralCoverageFixedList { get; set; }
        public decimal? TotalFixedAssetAndDeposito { get; set; }
        public List<AppraisalResultCollateralCoverageLoanResponse> CollateralCoverageLoanList { get; set; }
        public decimal? TotalLoanAndStock { get; set; }
        public decimal? TotalCollateral { get; set; }
        public List<AppraisalResultTotalCoverageResponse> TotalCoverageList { get; set; }
        public string Remark { get; set; }
    }
}
