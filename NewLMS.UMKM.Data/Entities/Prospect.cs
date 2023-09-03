using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.UMKM.Data.Enums;

namespace NewLMS.UMKM.Data.Entities
{
    public class Prospect : BaseEntity
    {
        #region Account Office
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProspectId { get; set; }

        [MaxLength(20)]
        public string AccountOfficer { get; set; }

        [MaxLength(4)]
        [ForeignKey(nameof(RfBranch))]
        public string BranchId { get; set; }

        [ForeignKey(nameof(RfOwnerCategory))]
        public int? OwnerCategoryId { get; set; }

        [ForeignKey(nameof(RfGender))]
        public string? GenderId { get; set; }

        [ForeignKey(nameof(RfCompanyStatus))]
        public int? CompanyStatusId { get; set; }

        #endregion

        #region Debitur
        public string NoIdentity { get; set; }

        [MaxLength(80)]
        public string Fullname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string SourceApplication { get; set; }
        #endregion

        #region Alamat Debitur
        [MaxLength(450)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Province { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string District { get; set; }

        [MaxLength(50)]
        public string Neighborhoods { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }
        #endregion

        #region PlaceAddress
        public bool SameAsIdentity { get; set; }

        [MaxLength(450)]
        public string PlaceAddress { get; set; }

        [MaxLength(50)]
        public string PlaceProvince { get; set; }

        [MaxLength(50)]
        public string PlaceCity { get; set; }

        [MaxLength(50)]
        public string PlaceDistrict { get; set; }

        [MaxLength(50)]
        public string PlaceNeighborhoods { get; set; }

        [ForeignKey(nameof(RfPlaceZipCode))]
        public int PlaceZipCodeId { get; set; }
        #endregion

        #region Product And Loan
        [ForeignKey(nameof(RfProduct))]
        public string? ProductId { get; set; }

        #endregion

        #region Target

        [ForeignKey(nameof(RfApplicationType))]
        public int? ApplicationTypeId { get; set; }
        [ForeignKey(nameof(RfSectorLBU3))]
        public string? SectorLBU3Code { get; set; }
        [ForeignKey(nameof(RfCategory))]
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(RfServiceCode))]
        public string? ServiceCodeId { get; set; }
        public string Reason { get; set; }
        public long? TargetPlafond { get; set; }
        public DateTime? EstimateProcessDate { get; set; }
        #endregion

        #region Company Data - Personal
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyFullAddress { get; set; }
        [MaxLength(50)]
        public string CompanyProvince { get; set; }

        [MaxLength(50)]
        public string CompanyCity { get; set; }

        [MaxLength(50)]
        public string CompanyDistrict { get; set; }

        [MaxLength(50)]
        public string CompanyNeighborhoods { get; set; }

        [ForeignKey(nameof(RfCompanyZipCode))]
        public int? CompanyZipCodeId { get; set; }
        #endregion

        #region Company Data - Company
        [ForeignKey(nameof(RfCompanyGroup))]
        public int? CompanyGroupId { get; set; }
        [ForeignKey(nameof(RfCompanyType))]
        public int? CompanyTypeId { get; set; }
        #endregion

        #region ETC
        public string DataSource { get; set; } = "NewLMS";
        #endregion
        public EnumProspectStatus Status { get; set; }

        public RfParameterDetail RfCompanyGroup { get; set; }
        public RfParameterDetail RfCompanyStatus { get; set; }
        public RfParameterDetail RfOwnerCategory { get; set; }
        public RfParameterDetail RfCompanyType { get; set; }
        public RfParameterDetail RfCategory { get; set; }
        public RfParameterDetail RfApplicationType { get; set; }

        public RfBranch RfBranch { get; set; }
        public RfProduct RfProduct { get; set; }
        public RfGender RfGender { get; set; }

        public RfSectorLBU3 RfSectorLBU3 { get; set; }
        public RfZipCode RfZipCode { get; set; }
        public RfZipCode RfPlaceZipCode { get; set; }
        public RfZipCode RfCompanyZipCode { get; set; }
        public RfInstituteCode RfServiceCode { get; set; }
    }
}
