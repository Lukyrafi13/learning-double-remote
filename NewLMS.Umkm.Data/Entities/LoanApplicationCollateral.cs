using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationCollateral : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AppId")]
        public LoanApplication LoanApplication { get; set; }
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
        [ForeignKey("RfZipCodeCollateralId")]
        public RfZipCode CollateralZipCode { get; set; }
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
        [ForeignKey("RfZipCodeId")]
        public RfZipCode RfZipCode { get; set; }
        public string OwnerNeighborhoods { get; set; }
        public string OwnerDistrict { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerProvince { get; set; }
        public string OwnerNPWP { get; set; }
        public string OwnerJob { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }

        // Pasangan
        public string NamaCouple { get; set; }
        public string TempatLahirCouple { get; set; }
        public DateTime? TanggalLahirCouple { get; set; }
        public string CoupleNoIdentity { get; set; }
        public DateTime? CoupleIdentityExpiryDate { get; set; }
        public bool? CoupleIdentityLifetime { get; set; }
        public string CoupleAdress { get; set; }
        [ForeignKey("RfZipCodeCoupleId")]
        public RfZipCode RfZipCodeCouple { get; set; }
        public string CoupleNeighborhoods { get; set; }
        public string CoupleDistrict { get; set; }
        public string CoupleCity { get; set; }
        public string CoupleProvince { get; set; }
        public string CoupleNPWP { get; set; }
        public string CouplePekerjaan { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFMappingAgunan2Id { get; set; }
        public Guid? RFJenisKendaraanAgunanId { get; set; }
        public Guid? RFDocumentId { get; set; }
        public Guid? RFVehMakerId { get; set; }
        public Guid? RFVehClassId { get; set; }
        public Guid? RFVehModelId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFJenisAktaId { get; set; }
        public int? RfZipCodeCollateralId { get; set; }
        public int? RfZipCodeId { get; set; }
        public int? RfZipCodeCoupleId { get; set; }
    }
}