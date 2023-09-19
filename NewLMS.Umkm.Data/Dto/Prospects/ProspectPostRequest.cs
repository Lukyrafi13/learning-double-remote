using System;

#nullable enable
namespace NewLMS.Umkm.Data.Dto.Prospects
{
    public class ProspectPostRequest
    {
        public string? Fullname { get; set; }
        public int? CompanyStatusId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? ZipCodeId { get; set; }
        public string? Neighborhoods { get; set; }
        public int? ApplicationTypeId { get; set; }
        public long TargetPlafond { get; set; }
        public DateTime EstimateProcessDate { get; set; }
        public string? ProductId { get; set; }
        public int? OwnerCategoryId { get; set; }
        public string? GenderId { get; set; }
        public string? SectorLBU1Code { get; set; }
        public string? SectorLBU2Code { get; set; }
        public string? SectorLBU3Code { get; set; }
        public int? CategoryId { get; set; }
        public string? InstituteCode { get; set; }
        public string? AccountOfficer { get; set; }
        public string? BranchId { get; set; }
        public string? NoIdentity { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IdCardAddress { get; set; }
        public string? PlaceAddress { get; set; }
        public int? PlaceZipCodeId { get; set; }
        public string? PlaceNeighborhoods { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyFullAddress { get; set; }
        public string? CompanyNeighborhoods { get; set; }
        public string? CompanyDistrict { get; set; }
        public string? CompanyProvince { get; set; }
        public int? CompanyZipCodeId { get; set; }
        public int? CompanyGroupId { get; set; }
        public string? CompanyTypeId { get; set; }
        public string? Reason { get; set; }
        public string? DataSource { get; set; }
        public string? OtherCompanyType { get; set; }
    }
}
