using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers
{
    public class ApprShopApartmentSummaryRequest
    {
        public List<ApprShopApartmentRequest> BaseData { get; set; }
        public decimal? CurrShopValue { get; set; }
        public decimal? CurrShopMarketValue { get; set; }
        public double? PctLiquidationValue { get; set; }
        public decimal? LiquidationValue { get; set; }
    }
}
