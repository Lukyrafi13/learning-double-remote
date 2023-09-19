using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprLandBuildingResponse
    {
        public int? DataNumber { get; set; }

        /* Form Perhitungan sub-menu */
        public string PropertyType { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public SimpleResponse<string> Provinsi { get; set; }
        public SimpleResponse<string> KotaKabupaten { get; set; }
        public SimpleResponse<string> Kecamatan { get; set; }
        public SimpleResponseWithPostCode<string> Kelurahan { get; set; }
        public double? ObjectDistance { get; set; }
        public string DataSource { get; set; }
        public string PhoneNumber { get; set; }
        public SimpleResponse<Guid> Offer { get; set; }
        public int? OfferTime { get; set; }
        public decimal? OfferValue { get; set; }
        public double? PctDiscount { get; set; }
        /* End */

        /* Spesifikasi data bangunan sub-menu */
        public SimpleResponse<Guid> BuildingCategory { get; set; }
        public int? EconomicalAge { get; set; }
        public double? BuildingArea { get; set; }
        public int? YearBuilt { get; set; }
        public int? RenovatedYear { get; set; }
        public double? PctRenovationAdjustment { get; set; }
        public double? PctDepreciationAdjustment { get; set; }
        public decimal? CurrBuildingValue { get; set; }
        /* End */

        /* Spesifikasi data tanah sub-menu */
        public SimpleResponse<Guid> LandDocument { get; set; }
        public double? LandArea { get; set; }
        public SimpleResponse<Guid> LandForm { get; set; }
        public double? FrontageWidth { get; set; }
        public double? RoadWidth { get; set; }
        public SimpleResponse<Guid> LandPosition { get; set; }
        public SimpleResponse<Guid> LandCondition { get; set; }
        public string Allotment { get; set; }
        public SimpleResponse<Guid> Topografi { get; set; }
        /* End */

        /* Data 1..n */
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

        public static implicit operator ApprLandBuildingResponse(List<ApprLandBuildingResponse> v)
        {
            throw new NotImplementedException();
        }
        /* End */
    }
}
