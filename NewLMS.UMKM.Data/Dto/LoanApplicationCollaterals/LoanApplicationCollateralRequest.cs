using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals
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
    }
}

