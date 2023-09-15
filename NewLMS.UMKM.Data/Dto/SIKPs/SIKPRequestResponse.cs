﻿using System;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfMarital;
using NewLMS.UMKM.Data.Dto.RfEducation;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Dto.RfLinkAge;

namespace NewLMS.UMKM.Data.Dto.SIKPs
{
    public class SIKPRequestResponse : BaseResponse
	{
        public string Fullname { get; set; }

        #region Debtor
        public string DebtorNPWP { get; set; }
        public string DebtorNoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DebtorSectorLBU3Code { get; set; }
        public string DebtorGenderId { get; set; }
        public string DebtorMaritalStatusId { get; set; }
        public string DebtorEducationId { get; set; }
        public string DebtorAddress { get; set; }
        public string DebtorProvince { get; set; }
        public string DebtorCity { get; set; }
        public string DebtorDistrict { get; set; }
        public string DebtorNeighborhoods { get; set; }
        public string DebtorZipCode { get; set; }
        public int DebtorZipCodeId { get; set; }
        #endregion

        #region DebtorCompany
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
        public string DebtorCompanyLingkageId { get; set; }
        public bool DebtorCompanySubisdyStatus { get; set; }
        public string DebtorCompanyPreviousSubsidy { get; set; }
        #endregion

        public virtual RfSectorLBU3Response RfSectorLBU3 { get; set; }
        public virtual RfGenderResponse RfGender { get; set; }
        public virtual RfMaritalResponse RfMarital { get; set; }
        public virtual RfEducationResponse RfEducation { get; set; }
        public virtual RfZipCodeResponse DebtorRfZipCode { get; set; }
        public virtual RfZipCodeResponse DebtorCompanyRfZipCode { get; set; }
        public virtual RfLinkAgeResponse DebtorCompanyRfLinkage { get; set; }
    }
}

