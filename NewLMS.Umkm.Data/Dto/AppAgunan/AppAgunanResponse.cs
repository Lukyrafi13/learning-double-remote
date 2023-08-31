using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data.Dto.RFDocuments;
using NewLMS.UMKM.Data.Dto.RFMappingAgunan2s;
using NewLMS.UMKM.Data.Dto.RFMARITALs;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;
using NewLMS.UMKM.Data.Dto.RFVehModels;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using System;
namespace NewLMS.UMKM.Data.Dto.AppAgunans
{
    public class AppAgunanResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid? LoanApplicationGuid { get; set; }

        public string DocumentNumber { get; set; }
        public DateTime? DocumentPublishedDate { get; set; }
        public DateTime? DocumentExpiryDate { get; set; }
        public string DocumentPublisher { get; set; }

        public string ProductionYear { get; set; }
        public string MachineNumber { get; set; }
        public string FrameNumber { get; set; }
        public string DomicileBySTNK { get; set; }

        // Girik/Leter C - Kios/Los/Dasaran/Lapak
        public string MarketLocationName { get; set; }
        public string MeasurementLetterNumber { get; set; }
        public string SituationPictureMasurementLetterNumber { get; set; }
        public string CollateralAddress { get; set; }

        public RfZipCodeResponse RfZipCodeCollateral { get; set; }

        public string CollateralNeighborhoods { get; set; }
        public string CollateralDistrict { get; set; }
        public string CollateralCity { get; set; }
        public string CollateralProvince { get; set; }
        public string CollateralDocumentNeighborhoods { get; set; }
        public string CollateralDocumentDistrict { get; set; }
        public string CollateralDocumentCity { get; set; }
        public string CollateralDocumentProvince { get; set; }

        // Izin Hak Pemakaian Lainnya - Kios/Los/Dasaran/Lapak
        public string RightOwnerName { get; set; }
        public string LandLocation { get; set; }
        public string HTRating { get; set; }
        public DateTime? MeasurementLetterDate { get; set; }

        // Akta Jual Beli/Sertifkat HGP/SPTB/Tanah Adat - Rumah Tapak
        public double? LandSurfaceArea { get; set; }
        public double? BuildingSurfaceArea { get; set; }
        public string BuildingPermit { get; set; }
        public string TaxObjectNumber { get; set; }
        public string NJOPPBBValue { get; set; }
        public string NorthernPerimeter { get; set; }
        public string SouthernPerimeter { get; set; }
        public string WestPerimeter { get; set; }
        public string EastPerimeter { get; set; }

        // Pemilik Debitur
        public bool? CollateralOwnedByDebtor { get; set; }
        public string OtherRelation { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPlaceOfBirth { get; set; }
        public DateTime? OwnerDateOfBirth { get; set; }
        public string OwnerNoIdentity { get; set; }
        public DateTime? IdentityExpiryDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string OwnerAddress { get; set; }
        public RfZipCodeResponse RfZipCode { get; set; }

        public string OwnerNeighborhoods { get; set; }
        public string OwnerDistrict { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerProvince { get; set; }
        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }

        // Pasangan
        public string CoupleName { get; set; }
        public string BirthOfPlaceCouple { get; set; }
        public DateTime? BithOfDateCouple { get; set; }
        public string CoupleNoIdentity { get; set; }
        public DateTime? CoupleIdentityExpiryDate { get; set; }
        public bool? CoupleIdentityLifetime { get; set; }
        public string CoupleAdress { get; set; }
        public RfZipCodeResponse RfZipCodeCouple { get; set; }
        public string CoupleNeighborhoods { get; set; }
        public string CoupleDistrict { get; set; }
        public string CoupleCity { get; set; }
        public string CoupleProvince { get; set; }
        public string CoupleNPWP { get; set; }
        public string CouplePekerjaan { get; set; }        
        public RfAppTypeResponseDto RfAppType { get; set; }
        public RFMappingAgunan2ResponseDto RFMappingAgunan2 { get; set; }
        public RfParameterDetailResponse ParamVehTypeCollateral { get; set; }
        public RFDocumentResponseDto RFDocument { get; set; }
        public RFVEHMAKERResponseDto RFVEHMAKER { get; set; }
        public RFVEHCLASSResponseDto RFVEHCLASS { get; set; }
        public RFVehModelResponseDto RFVehModel { get; set; }
        public RfParameterDetailResponse ParamRealationCol { get; set; }
        public RFMARITALResponseDto MaritalId { get; set; }
        public RfParameterDetailResponse ParamDeedType { get; set; }
    }
}
