﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprShopApartmentRequest
    {
        /* FORM PERHITUNGAN */
        public int? DataNumber { get; set; }
        public Guid? DataType { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string AddressReference { get; set; }
        public string PhoneNumber { get; set; }
        public double? ObjectDistance { get; set; }
        public double? RoadWidth { get; set; }
        public string DataUsage { get; set; }
        public Guid? Allotment { get; set; }
        public double? AreaTotalBuildingFloor { get; set; }
        public double? AreaActualLandControlled { get; set; }
        public double? AreaFirstFloorBuilding { get; set; }
        public double? AreaEqualizationCoefficient { get; set; }
        public Guid? LandForm { get; set; }
        public Guid? LandCondition { get; set; }
        public Guid? Ownership { get; set; }
        public string FacilityInfrastructure { get; set; }
        public decimal? CurrOffer { get; set; }
        public decimal? CurrPriceEqualization { get; set; }
        public double? PctDiscount { get; set; }
        public decimal? CurrPriceAfterDiscount { get; set; }
        public decimal? CurrShopPriceM2 { get; set; }
        public string Remark { get; set; }

        /* FORM PENYESUAIAN */
        public decimal? CurrAdjustment { get; set; }
        public double? PctLocation { get; set; }
        public double? PctBuildingArea { get; set; }
        public double? PctBuildingDesign { get; set; }
        public double? PctPhysicBuildingCondition { get; set; }
        public double? PctPhysicLandArea { get; set; }
        public double? PctOwnership { get; set; }
        public double? PctOther { get; set; }
        public double? PctTotalAdjustment { get; set; }
        public double? PctTotalAbsolute { get; set; }
        public double? PctDataWeight { get; set; }
        public double? PctCalculation { get; set; }
        public double? PctAccuracy { get; set; }
        public decimal? CurrLocation { get; set; }
        public decimal? CurrBuildingArea { get; set; }
        public decimal? CurrBuildingDesign { get; set; }
        public decimal? CurrPhysicBuildingCondition { get; set; }
        public decimal? CurrPhysicLandArea { get; set; }
        public decimal? CurrOwnership { get; set; }
        public decimal? CurrOther { get; set; }
        public decimal? CurrTotalAdjustment { get; set; }
        public decimal? CurrUnitValueM2 { get; set; }
    }
}
