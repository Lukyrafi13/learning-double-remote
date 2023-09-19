using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprLandBuildingSummaryRequest
    {
        public List<ApprLandBuildingRequest> BaseData { get; set; }
        public double? PctTotalIndicatorValue { get; set; }
        public decimal? CurrTotalIndicatorValue { get; set; }
        public decimal? CurrRounding { get; set; }
        public decimal? CurrLandMarketValue { get; set; }
        public decimal? CurrBuildingMarketValue { get; set; }
        public decimal? CurrAssetMarketValue { get; set; }
        public double? PctLandLiquidationValue { get; set; }
        public decimal? LandLiquidationValue { get; set; }
        public double? PctBuildingLiquidationValue { get; set; }
        public decimal? BuildingLiquidationValue { get; set; }
    }
}
