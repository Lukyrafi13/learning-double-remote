using System;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfInstituteCodes;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;

namespace NewLMS.UMKM.Data.Dto.Prospects
{
    public class ProspectResponse : BaseResponse
    {
        #region Account Office
        public Guid Id { get; set; }

        public string ProspectId { get; set; }

        public string AccountOfficer { get; set; }

        public string BranchId { get; set; }

        public int? OwnerCategoryId { get; set; }

        public string? GenderId { get; set; }

        public int? CompanyStatusId { get; set; }

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
        public string? ProductId { get; set; }

        #endregion

        #region Target

        public int? ApplicationTypeId { get; set; }
        public string? SectorLBU3Code { get; set; }
        public int? CategoryId { get; set; }
        public string? ServiceCodeId { get; set; }
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

        public int? CompanyZipCodeId { get; set; }
        #endregion

        #region Company Data - Company
        public int? CompanyGroupId { get; set; }
        public int? CompanyTypeId { get; set; }
        #endregion

        #region ETC
        public string DataSource { get; set; }
        #endregion
        public bool ProcessStatus { get; set; }

        public RfParameterDetailResponse RfCompanyGroup { get; set; }
        public RfParameterDetailResponse RfCompanyStatus { get; set; }
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public RfParameterDetailResponse RfCategory { get; set; }
        public RfParameterDetailResponse RfApplicationType { get; set; }

        public RfBranchResponse RfBranch { get; set; }
        public RfProductResponse RfProduct { get; set; }
        public RfGenderResponse RfGender { get; set; }
        public RfCompanyTypeResponse RfCompanyType { get; set; }

        public RfSectorLBU3Response RfSectorLBU3 { get; set; }
        public RfZipCodeResponse RfZipCode { get; set; }
        public RfZipCodeResponse RfPlaceZipCode { get; set; }
        public RfZipCodeResponse RfCompanyZipCode { get; set; }
        public RfInstituteCodeResponse RfServiceCode { get; set; }
    }

    public class ProspectTableResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string ProspectId { get; set; }
        public string Fullname { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public string DataSource { get; set; }
    }
}
