using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalResults
{
    public class AppraisalResultTotalCoverageResponse
    {
        public SimpleResponseWithCurrency<Guid> LoanFacility { get; set; }
        public double? PctTotalCoverage { get; set; }
        public double? PctTotalFacilityCoverage { get; set; }
    }
}
