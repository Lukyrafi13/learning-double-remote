using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers
{
    public class ApprLandBuildingRequest
    {
        public int DataNumber { get; set; }

        /* Form Perhitungan sub-menu */
        public string PropertyType { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string AddressReference { get; set; }
        public double? ObjectDistance { get; set; }
        public string DataSource { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? Offer { get; set; }
        public int? OfferTime { get; set; }
        public decimal? OfferValue { get; set; }
        public double? PctDiscount { get; set; }
        /* End */

        /* Spesifikasi data bangunan sub-menu */
        public Guid? BuildingCategory { get; set; }
        public int? EconomicalAge { get; set; }
        public double? BuildingArea { get; set; }
        public int? YearBuilt { get; set; }
        public int? RenovatedYear { get; set; }
        public double? PctRenovationAdjustment { get; set; }
        public double? PctDepreciation { get; set; }
        public double? PctDepreciationAdjustment { get; set; }
        public double? PctDepreciationFinal { get; set; }
        public decimal? CurrBuildingValue { get; set; }
        public decimal? CurrDepreciation { get; set; }
        public decimal? CurrRcnDepreciation { get; set; }
        public decimal? CurrBuildingMarketValue { get; set; }
        /* End */

        /* Spesifikasi data tanah sub-menu */
        public Guid? LandDocument { get; set; }
        public double? LandArea { get; set; }
        public Guid? LandForm { get; set; }
        public double? FrontageWidth { get; set; }
        public double? RoadWidth { get; set; }
        public Guid? LandPosition { get; set; }
        public Guid? LandCondition { get; set; }
        public string Allotment { get; set; }
        public Guid? Topografi { get; set; }
        public double? PropertyValueIndicator { get; set; }
        public double? BuildingMarketValueIndicator { get; set; }
        public double? LandValueIndicator { get; set; }
        public double? LandValueAreaIndicator { get; set; }
        /* End */

        /* Data 1..n */
        public decimal? CurrLocation { get; set; }
        public double? PctLocation { get; set; }
        public decimal? CurrLandDocument { get; set; }
        public double? PctLandDocument { get; set; }
        public decimal? CurrLandArea { get; set; }
        public double? PctLandArea { get; set; }
        public decimal? CurrFrontageWidth { get; set; }
        public double? PctFrontageWidth { get; set; }
        public decimal? CurrRoadWidth { get; set; }
        public double? PctRoadWidth { get; set; }
        public decimal? CurrActivaPosition { get; set; }
        public double? PctActivaPosition { get; set; }
        public decimal? CurrFacility { get; set; }
        public double? PctFacility { get; set; }
        public decimal? CurrUsage { get; set; }
        public double? PctUsage { get; set; }
        public decimal? CurrOther1 { get; set; }
        public double? PctOther1 { get; set; }
        public decimal? CurrOther2 { get; set; }
        public double? PctOther2 { get; set; }
        public decimal? CurrTotalAdjustment { get; set; }
        public double? PctTotalAdjustment { get; set; }
        public double? IndicatorValue { get; set; }
        public double? PctAdjustmentAbsolute { get; set; }
        /* End */

        /* Weight sub-menu */
        public double? PctDataWeight { get; set; }
        public double? CurrDataWeight { get; set; }
        /* End */
    }
}
