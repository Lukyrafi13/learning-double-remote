using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationCollateral : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        
        [ForeignKey(nameof(RfCollateralBC))]
        public string CollateralBCId { get; set; }

        [ForeignKey(nameof(RfDocument))]
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

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }
        public double? LanArea { get; set; }
        public string BuildingPermit { get; set; }
        public string NOPNumber { get; set; }
        public string NJOPPBBNumber { get; set; }
        public double? BuildingArea { get; set; }

        [ForeignKey(nameof(RfVehMaker))]
        public string VehMakerCode { get; set; }
        
        [ForeignKey(nameof(RfVehClass))]
        public string VehClassCode { get; set; }
        public int? YearProduction { get; set; }
        public string MachineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string CityDomisili { get; set; }

        [ForeignKey(nameof(RfVehModel))]
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

        [ForeignKey(nameof(RfTransportationType))]
        public string TransportationTypeCode { get; set; }


        public virtual RfVehModel RfVehModel { get; set; }
        public virtual RfDocument RfDocument { get; set; }
        public virtual RfVehClass RfVehClass { get; set; }
        public virtual RfVehMaker RfVehMaker { get; set; }
        public virtual LoanApplicationCollateralOwner LoanApplicationCollateralOwner { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }

        public virtual RfZipCode RfZipCode { get; set; }
        public virtual RfCollateralBC RfCollateralBC { get; set; }
        public virtual RfTransportationType RfTransportationType { get; set; }
    }
}
