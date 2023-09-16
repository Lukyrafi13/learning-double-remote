using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.ShopAppartmentWorkPaper
{
    public class ApprWorkPaperShopApartmentHeaderResponse
    {
        public List<ApprShopApartmentResponse> MarketData { get; set; }
        public decimal? CurrShopValue { get; set; }
        public decimal? CurrShopMarketValue { get; set; }
        public List<ApprLiquidationResponse> LiquidationData { get; set; }
        public double? PctLiquidationValue { get; set; }
        // public decimal? LiquidationValue { get; set; }
    }
}
