using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
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
        public Guid? RfOwnerCategoryId { get; set; }

        [ForeignKey(nameof(RfGender))]
        public Guid? RfGenderId { get; set; }

        [ForeignKey(nameof(RfCompanyStatus))]
        public Guid? RfCompanyStatusId { get; set; }

        #endregion

        #region Debitur
        public string NoIdentity { get; set; }

        [MaxLength(80)]
        public string Fullname => FirstName + " " + LastName;
		public string FirstName { get; set; }
		public string LastName { get; set; }

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
        public Guid? RfProductId { get; set; }
        
        #endregion

        #region Target
        
        [ForeignKey(nameof(RfAppType))]
        public Guid? RfAppTypeId { get; set; }
        [ForeignKey(nameof(RfTargetStatus))]
        public Guid? RfTargetStatusId { get; set; }
        [ForeignKey(nameof(RfSectorLBU3))]
        public string RfSectorLBU3Code { get; set; }
        [ForeignKey(nameof(RfCategory))]
        public Guid? RfCategoryId { get; set; }
        [ForeignKey(nameof(RfServiceCode))]
        public Guid? RfServiceCodeId { get; set; }
        public string Reason { get; set; }
        public double? TargetPladfond { get; set; }
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
        public int CompanyZipCodeId { get; set; }
        #endregion

        #region Company Data - Company
        [ForeignKey(nameof(RfCompanyGroup))]
        public Guid? RfCompanyGroupId { get; set; }
        [ForeignKey(nameof(RfCompanyType))]
        public Guid? RfCompanyTypeId { get; set; }
        public string OtherCompanyType { get; set; }
        #endregion

        #region ETC
        public string DataSource { get; set; }
        #endregion

        public RfCompanyGroup RfCompanyGroup { get; set; }
        public RfCompanyStatus RfCompanyStatus { get; set; }
        public RfCompanyType RfCompanyType { get; set; }

        public RfBranch RfBranch { get; set; }
        public RfProduct RfProduct { get; set; }
        public RfGender RfGender { get; set; }

        public RfSectorLBU3 RfSectorLBU3 { get; set; }
        public RfOwnerCategory RfOwnerCategory { get; set; }
        public RfZipCode RfZipCode { get; set; }
        public RfZipCode RfPlaceZipCode { get; set; }
        public RfZipCode RfCompanyZipCode { get; set; }
        public RfAppType RfAppType { get; set; }
        public RfTargetStatus RfTargetStatus { get; set; }
        public RfCategory RfCategory { get; set; }
        public RfServiceCode RfServiceCode { get; set; }
    }
}
