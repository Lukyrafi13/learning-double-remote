using System;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Data.Dto.RfVehMaker;
using NewLMS.Umkm.Data.Dto.RfVehClass;
using NewLMS.Umkm.Data.Dto.RfVehModel;
using NewLMS.Umkm.Data.Dto.RfDocument;
using NewLMS.Umkm.Data.Dto.RfTransportationType;
using NewLMS.Umkm.Data.Dto.RfCollateralBC;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners
{
    public class LoanApplicationCollateralResponse : BaseResponse
    {
        public Guid Id { get; set; }
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

        public RfZipCodeResponse RfZipCode { get; set; }
        public RfDocumentSimpleResponse RfDocument { get; set; }
        public RfVehMakerSimpleResponse RfVehMaker { get; set; }
        public RfVehClassSimpleResponse RfVehClass { get; set; }
        public RfVehModelSimplelResponse RfVehModel { get; set; }
        public RfParameterDetailSimpleResponse TypeOfDeed { get; set; }
        public RfTransportationTypeSimpleResponse RfTransportationType { get; set; }
        public RfCollateralBCResponse RfCollateralBC { get; set; }
        public LoanApplicationCollateralOwnerResponse LoanApplicationCollateralOwner { get; set; }
        public LoanApplicationResponse LoanApplication { get; set; }
    }
}

