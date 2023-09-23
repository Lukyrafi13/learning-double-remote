using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprWorkPaperLandBuildings : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprWorkPaperLandBuildingGuid { get; set; }
        [ForeignKey(nameof(ApprWorkPaperLandBuildingSummaries))]
        public Guid ApprWorkPaperLandBuildingSummaryGuid { get; set; }
        [ForeignKey(nameof(ApprBuildingTemplates))]
        public Guid? ApprBuildingTemplateGuid { get; set; }
        [ForeignKey(nameof(ApprLandTemplates))]
        public Guid? ApprLandTemplateGuid { get; set; }
        [ForeignKey(nameof(ApprProductiveLandTemplates))]
        public Guid? ApprProductiveLandTemplateGuid { get; set; }
        public int? DataNumber { get; set; }

        /* FORM PERHITUNGAN */
        public string PropertyType { get; set; }
        public string Address { get; set; }
        [MaxLength(4)]
        public string Rt { get; set; }
        [MaxLength(4)]
        public string Rw { get; set; }
        [ForeignKey(nameof(WilayahVillages))]
        public string AddressReference { get; set; }
        public double? ObjectDistance { get; set; }
        public string DataSource { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey(nameof(OfferFK))]
        public Guid? Offer { get; set; }
        public int? OfferTime { get; set; }
        public decimal? OfferValue { get; set; }
        public double? PctDiscount { get; set; }

        /* SPESIFIKASI DATA BANGUNAN */
        [ForeignKey(nameof(BuildingCategoryFK))]
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

        /* SPESIFIKASI DATA TANAH */
        [ForeignKey(nameof(LandDocumentFK))]
        public Guid? LandDocument { get; set; }
        public double? LandArea { get; set; }
        [ForeignKey(nameof(LandFormFK))]
        public Guid? LandForm { get; set; }
        public double? FrontageWidth { get; set; }
        public double? RoadWidth { get; set; }
        [ForeignKey(nameof(LandPositionFK))]
        public Guid? LandPosition { get; set; }
        [ForeignKey(nameof(LandConditionFK))]
        public Guid? LandCondition { get; set; }
        public string Allotment { get; set; }
        [ForeignKey(nameof(TopografiFK))]
        public Guid? Topografi { get; set; }
        public double? PropertyValueIndicator { get; set; }
        public double? BuildingMarketValueIndicator { get; set; }
        public double? LandValueIndicator { get; set; }
        public double? LandValueAreaIndicator { get; set; }

        /* DATA */
        public double? PctLocation { get; set; }
        public double? PctLandDocument { get; set; }
        public double? PctLandArea { get; set; }
        public double? PctFrontageWidth { get; set; }
        public double? PctRoadWidth { get; set; }
        public double? PctActivaPosition { get; set; }
        public double? PctFacility { get; set; }
        public double? PctUsage { get; set; }
        public double? PctOther1 { get; set; }
        public double? PctOther2 { get; set; }
        public double? PctTotalAdjustment { get; set; }
        public double? IndicatorValue { get; set; }
        public double? PctAdjustmentAbsolute { get; set; }
        public decimal? CurrLocation { get; set; }
        public decimal? CurrLandDocument { get; set; }
        public decimal? CurrLandArea { get; set; }
        public decimal? CurrFrontageWidth { get; set; }
        public decimal? CurrRoadWidth { get; set; }
        public decimal? CurrActivaPosition { get; set; }
        public decimal? CurrFacility { get; set; }
        public decimal? CurrUsage { get; set; }
        public decimal? CurrOther1 { get; set; }
        public decimal? CurrOther2 { get; set; }
        public decimal? CurrTotalAdjustment { get; set; }

        /* WEIGHT */
        public double? PctDataWeight { get; set; }
        public double? CurrDataWeight { get; set; }

        public virtual ApprWorkPaperLandBuildingSummaries ApprWorkPaperLandBuildingSummaries { get; set; }
        public virtual WilayahVillages WilayahVillages { get; set; }
        public virtual ApprBuildingTemplates ApprBuildingTemplates { get; set; }
        public virtual ApprLandTemplates ApprLandTemplates { get; set; }
        public virtual ApprProductiveLandTemplate ApprProductiveLandTemplates { get; set; }
        public virtual Parameters OfferFK { get; set; }
        public virtual Parameters BuildingCategoryFK { get; set; }
        public virtual Parameters LandDocumentFK { get; set; }
        public virtual Parameters LandFormFK { get; set; }
        public virtual Parameters LandPositionFK { get; set; }
        public virtual Parameters LandConditionFK { get; set; }
        public virtual Parameters TopografiFK { get; set; }
    }
}
