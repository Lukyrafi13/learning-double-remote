using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class SIKPResponse : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(SIKP))]
        [Required]
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public bool? Valid { get; set; }
        public string ValidationMessage { get; set; }

        #region Debtor
        public string DebtorNPWP { get; set; }
        public string DebtorNoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey(nameof(RfSectorLBU3))]
        public string? DebtorSectorLBU3Code { get; set; }
        [ForeignKey(nameof(RfGender))]
        public string? DebtorGenderId { get; set; }
        [ForeignKey(nameof(RfMarital))]
        public string? DebtorMaritalStatusId { get; set; }
        [ForeignKey(nameof(RfEducation))]
        public string? DebtorEducationId { get; set; }
        [ForeignKey(nameof(RfJob))]
        public string? DebtorJobId { get; set; }
        public string DebtorAddress { get; set; }
        public string DebtorProvince { get; set; }
        public string DebtorCity { get; set; }
        public string DebtorDistrict { get; set; }
        public string DebtorNeighborhoods { get; set; }
        public string DebtorZipCode { get; set; }
        [ForeignKey(nameof(DebtorRfZipCode))]
        public int? DebtorZipCodeId { get; set; }
        #endregion

        #region DebtorCompany
        public DateTime? DebtorCompanyEstablishmentDate { get; set; }
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
        [ForeignKey(nameof(DebtorCompanyRfLinkage))]
        public string? DebtorCompanyLingkageId { get; set; }
        public bool DebtorCompanySubisdyStatus { get; set; }
        public string DebtorCompanyPreviousSubsidy { get; set; }
        #endregion


        public virtual SIKP SIKP { get; set; }
        public virtual RfSectorLBU3? RfSectorLBU3 { get; set; }
        public virtual RfGender? RfGender { get; set; }
        public virtual RfMarital? RfMarital { get; set; }
        public virtual RfJob? RfJob { get; set; }
        public virtual RfEducation? RfEducation { get; set; }
        public virtual RfZipCode? DebtorRfZipCode { get; set; }
        public virtual RfZipCode? DebtorCompanyRfZipCode { get; set; }
        public virtual RfLinkAge? DebtorCompanyRfLinkage { get; set; }

    }
}

