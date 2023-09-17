using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.CollateralInsurances
{
    public class CollateralInsurancePostRequest
    {
        public Guid Broker { get; set; }
        public string Insurance { get; set; }
        public string Coverage { get; set; }
        public int? Tenor { get; set; }
        public decimal? CoverageValue { get; set; }
        public decimal? EstimatePremi { get; set; }
        public decimal? PolicyCost { get; set; }
        public decimal? LifeInsuranceCommission { get; set; }
        public string TemplateMappingCode { get; set; }
    }
}
