using System;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Dto.RfVehMaker;
using NewLMS.UMKM.Data.Dto.RfVehClass;
using NewLMS.UMKM.Data.Dto.RfVehModel;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners
{
    public class LoanApplicationCollateralResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string CollateralBCId { get; set; }
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
        public RfZipCodeResponse RfZipCode { get; set; }
        public RfVehMakerSimpleResponse RfVehMaker { get; set; }
        public RfVehClassSimpleResponse RfVehClass { get; set; }
        public RfVehModelSimplelResponse RfVehModel { get; set; }
        public LoanApplicationCollateralOwnerResponse LoanApplicationCollateralOwner { get; set; }
    }
}

