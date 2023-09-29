using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationCollaterals
{
    public class LoanApplicationCollateralAndOwnerPostRequest
    {
        public LoanApplicationCollateralRequest LoanApplicationCollateral { get; set; }
        public LoanApplicationCollateralOwnerRequest LoanApplicationCollateralOwner { get; set; }
    }

    public class LoanApplicationCollateralRequest
    {
        public Guid LoanApplicationId { get; set; }
        public string CollateralBCId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentReleaseDate { get; set; }
        public DateTime? DocumentExpireDate { get; set; }
        public string DocumentPublisher { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }
        public int ZipCodeId { get; set; }
        public double? LanArea { get; set; }
        public string BuildingPermit { get; set; }
        public int? TypeOfDeedId { get; set; }
        public string NOPNumber { get; set; }
        public string NJOPPBBNumber { get; set; }
        public double? BuildingArea { get; set; }
        public string VehMakerCode { get; set; }
        public string VehClassCode { get; set; }
        public int? YearProduction { get; set; }
        public string MachineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string CityDomisili { get; set; }
        public string VehModelCode { get; set; }
        public string NameMarketLocation { get; set; }
        public string MeasurementLetterNumberImageSituation { get; set; }
        public string MeasurementLetterNumber { get; set; }
        public string NeigborhoodDocumentCollateral { get; set; }
        public string DistrictDocumentCollateral { get; set; }
        public string CityDocumentCollateral { get; set; }
        public string ProvinceDocumentCollateral { get; set; }
        public string NameCollateralHolder { get; set; }
        public string LandLocation { get; set; }
        public string RangkingHT { get; set; }
        public DateTime? DateMeasurementLetterNumber { get; set; }
        public string EastBoundaries { get; set; }
        public string WestBoundaries { get; set; }
        public string SouthBoundaries { get; set; }
        public string NorthBoundaries { get; set; }
        public string TransportationTypeCode { get; set; }
    }
}

