using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPostRequest
    {
    }

    public class LoanApplicationIDEPostRequest : LoanApplicationGetDetailTabRequest
    {
        public LoanApplicationInitialDataEntryRequest InitialData { get; set; }
        public LoanApplicationCreditScoringPostRequest CreditScoring { get; set; }
        public DebtorPostRequest Debtor { get; set; }
        public DebtorEmergencyPostRequest DebtorEmergency { get; set; }
        public DebtorCompanyPostRequest DebtorCompany { get; set; }
        public DebtorCompanyLegalPostRequest DebtorCompanyLegal { get; set; }
    }

    public class LoanApplicationInitialDataEntryRequest
    {
        public string ProductId { get; set; }
        public int OwnerCategoryId { get; set; }
        public bool? IsBusinessCycle { get; set; }
        public int? BusinessCycleId { get; set; }
        public int? BusinessCycleMonth { get; set; }
        public string BookingBranchId { get; set; }
    }

    public class LoanApplicationCreditScoringPostRequest
    {
        // Credit Scoring
        public int ScoResidentialReputationId { get; set; }
        public int ScoBankRelationId { get; set; }
        public int ScoBJBCreditHistoryId { get; set; }
        public int ScoTransacMethodId { get; set; }
        public int ScoAverageAccBalanceId { get; set; }
        public int ScoNeedLevelId { get; set; }
        public int ScoFinanceManagerId { get; set; }
        public int ScoBusinesLocationId { get; set; }
        public int ScoOtherPartyDebtId { get; set; }
        public int ScoCollateralId { get; set; }
    }

    public class DebtorPostRequest
    {
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string? NPWP { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? IdentityExpiredDate { get; set; }
        public bool? IdentityLifetime { get; set; }
        public string? MotherName { get; set; }
        public string? GenderId { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }
        public int? NumberOfDependents { get; set; }
        public int? ResidenceStatusId { get; set; }
        public int? ResidenceLiveTime { get; set; }
        public string? EducationId { get; set; }
        public string? MaritalStatusId { get; set; }
        public string? JobCode { get; set; }
        public string? MarriageCertificateNumber { get; set; }
        public DateTime? MarriageCertificateDate { get; set; }
        public string? MarriageCertificateIssuer { get; set; }
        public DebtorCouplePostRequest DebtorCouple { get; set; }
    }

    public class DebtorCouplePostRequest
    {
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string? NPWP { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool AddressSameAsDebtor { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public int? ZipCodeId { get; set; }
        public string? JobCode { get; set; }
    }

    public class DebtorEmergencyPostRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }
        public int ZipCodeId { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class DebtorCompanyPostRequest
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhoods { get; set; }
        public int? ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class DebtorCompanyLegalPostRequest
    {
        public string EstablishmentDeedNumber { get; set; }
        public DateTime EstablishmentDeedDate { get; set; }
        public string RegisterNumber { get; set; }
        public string NPWP { get; set; }
        public string LatestDeedChange { get; set; }
        public string SIUPNumber { get; set; }
        public DateTime SIUPDate { get; set; }
        public string TDPNumber { get; set; }
        public DateTime TDPDate { get; set; }
        public DateTime TDPDueDate { get; set; }
        public string SKNumber { get; set; }
        public DateTime SKDueDate { get; set; }
        public DateTime DeedDate { get; set; }
        public string SKDPNumber { get; set; }
        public DateTime SKDPDate { get; set; }
    }
}
