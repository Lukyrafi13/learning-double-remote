using System;
namespace NewLMS.UMKM.Data.Dto.Prospects
{
    public class ProspectPostRequestDto
    {
        #region Account Office

        //public string ProspectId { get; set; }

        public string AccountOfficer { get; set; }

        public string BranchId { get; set; }

        public Guid? RfOwnerCategoryId { get; set; }

        public Guid? RfGenderId { get; set; }

        public int? RfCompanyStatusId { get; set; }

        #endregion

        #region Debitur
        public string NoIdentity { get; set; }

        public string Fullname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string SourceApplication { get; set; }
        #endregion

        #region Alamat Debitur
        public string Address { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Neighborhoods { get; set; }
        
        public int ZipCodeId { get; set; }
        #endregion

        #region PlaceAddress
        public bool SameAsIdentity { get; set; }
        public string PlaceAddress { get; set; }

        public string PlaceProvince { get; set; }

        public string PlaceCity { get; set; }

        public string PlaceDistrict { get; set; }

        public string PlaceNeighborhoods { get; set; }
        
        public int PlaceZipCodeId { get; set; }
        #endregion

        #region Product And Loan
        public Guid? RfProductId { get; set; }
        
        #endregion

        #region Target
        public int? RfAppTypeId { get; set; }
        public Guid? RfTargetStatusId { get; set; }
        public string RfSectorLBU3Code { get; set; }
        public Guid? RfCategoryId { get; set; }
        public Guid? RfServiceCodeId { get; set; }
        public string Reason { get; set; }
        public double? TargetPladfond { get; set; }
        public DateTime? EstimateProcessDate { get; set; }
        #endregion
        
        #region Company Data - Personal
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyFullAddress { get; set; }
        public string CompanyProvince { get; set; }

        public string CompanyCity { get; set; }

        public string CompanyDistrict { get; set; }

        public string CompanyNeighborhoods { get; set; }
        
        public int CompanyZipCodeId { get; set; }
        #endregion

        #region Company Data - Company
        public int? RfCompanyGroupId { get; set; }
        public Guid? RfCompanyTypeId { get; set; }
        public string OtherCompanyType { get; set; }
        #endregion

        #region ETC
        public string DataSource { get; set; }
        #endregion
    }
}
