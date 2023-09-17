﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalResults
{
    public class AppraisalResultCollateralCoverageLoanResponse
    {
        public Guid CollateralBindingGuid { get; set; }
        public int? BindingRank { get; set; }
        public SimpleResponse<string> CollateralType { get; set; }
        public SimpleResponseWithCurrency<Guid> LoanFacility { get; set; }
        public decimal? BindingValue { get; set; }
        public double? PctCoverage { get; set; }
    }
}
