using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalResults
{
    public class AppraisalResultCollateralAppraisalResponse
    {
        public Guid DebtorCollateralGuid { get; set; }
        public Guid? AppraisalGuid { get; set; }
        public SimpleResponse<string> CollateralCode { get; set; }
        public SimpleResponse<string> PledgeType { get; set; }
        public string NoOwnershipProof { get; set; }
        public decimal? MarketInternalValue { get; set; }
        public decimal? LiquidasiInternalValue { get; set; }
        public decimal? MarketExternalValue { get; set; }
        public decimal? LiquidasiExternalValue { get; set; }
        public decimal? CollateralInsurance { get; set; }
        public string AppraisalStatus { get; set; }
    }
}
