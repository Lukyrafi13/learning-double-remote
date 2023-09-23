using System;

namespace NewLMS.Umkm.Data.Dto.SIKPs
{
    public class SIKPRequestRequest
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Scheme { get; set; } = string.Empty;
        public bool Post { get; set; } = false;

        #region Debtor
        public string DebtorNPWP { get; set; }
        public string DebtorNoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DebtorSectorLBU3Code { get; set; }
        public string DebtorGenderId { get; set; }
        public string DebtorMaritalStatusId { get; set; }
        public string DebtorEducationId { get; set; }
        public string DebtorJobId { get; set; }
        public string DebtorAddress { get; set; }
        public string DebtorProvince { get; set; }
        public string DebtorCity { get; set; }
        public string DebtorDistrict { get; set; }
        public string DebtorNeighborhoods { get; set; }
        public string DebtorZipCode { get; set; }
        public int DebtorZipCodeId { get; set; }
        #endregion

        #region DebtorCompany
        public DateTime DebtorCompanyEstablishmentDate { get; set; }
        public string DebtorCompanyEstablishmentDeedNumber { get; set; }
        public string DebtorCompanyAddress { get; set; }
        public string DebtorCompanyProvince { get; set; }
        public string DebtorCompanyCity { get; set; }
        public string DebtorCompanyDistrict { get; set; }
        public string DebtorCompanyNeighborhoods { get; set; }
        public string DebtorCompanyZipCode { get; set; }
        public int DebtorCompanyZipCodeId { get; set; }
        public string DebtorCompanyPermit { get; set; }
        public long DebtorCompanyVentureCapital { get; set; }
        public long DebtorCompanyCreditValue { get; set; }
        public string DebtorCompanyPhone { get; set; }
        public string DebtorCompanyCollaterals { get; set; }
        public int DebtorCompanyEmployee { get; set; }
        public string DebtorCompanyLinkageId { get; set; }
        public string DebtorCompanyLinkageTypeId { get; set; }
        public bool DebtorCompanySubisdyStatus { get; set; }
        public string DebtorCompanyPreviousSubsidy { get; set; }
        #endregion
    }
}

