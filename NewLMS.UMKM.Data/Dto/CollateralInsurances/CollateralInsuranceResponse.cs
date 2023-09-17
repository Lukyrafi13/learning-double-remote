using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.CollateralInsurances
{
    public class CollateralInsuranceResponse
    {
        public Guid CollateralInsuranceGuid { get; set; }
        public Guid DebtorCollateralGuid { get; set; }
        public SimpleResponse<Guid> Broker { get; set; }
        public SimpleResponse<string> Insurance { get; set; }
        public SimpleResponse<string> Coverage { get; set; }
        public int? Tenor { get; set; }
        public decimal? CoverageValue { get; set; }
        public decimal? EstimatePremi { get; set; }
        public decimal? PolicyCost { get; set; }
        public decimal? LifeInsuranceCommission { get; set; }
        public SimpleResponseWithRate<string> TemplateMappingCode { get; set; }
    }
}
