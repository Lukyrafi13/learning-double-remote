using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalResults
{
    public class AppraisalResultCollateralBindingResponse
    {
        public Guid CollateralBindingGuid { get; set; }
        public SimpleResponse<string> CollateralCode { get; set; }
        public SimpleResponse<Guid> BindingTypeGuid { get; set; }
        public SimpleResponseWithCurrency<Guid> FacilityGuid { get; set; }
        public SimpleResponse<Guid> BindingGuid { get; set; }
        public decimal? BindingValue { get; set; }
        public int? BindingRank { get; set; }
    }
}
