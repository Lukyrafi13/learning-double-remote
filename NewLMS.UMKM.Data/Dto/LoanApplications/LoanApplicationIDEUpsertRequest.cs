using NewLMS.UMKM.Data.Dto.Debtor;
using NewLMS.UMKM.Data.Dto.DebtorCompany;
using NewLMS.UMKM.Data.Dto.DebtorCompanyLegal;
using NewLMS.UMKM.Data.Dto.DebtorCouple;
using NewLMS.UMKM.Data.Dto.DebtorEmergencies;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditScorings;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;

#nullable enable
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationIDEUpsertRequest
    {
        public LoanApplicationInitialDataEntryRequest? InitialDataEntry { get; set; }
    }

    public class LoanApplicationInitialDataEntryTabUpsertRequest
    {
        public LoanApplicationDataFasilitasRequest DataFasilitas { get; set; }
        public LoanApplicationCreditScoringRequest? CreditScoring { get; set; }
    }

    public class LoanApplicationDataFasilitasRequest
    {
        public string? ProductId { get; set; }
        public int? OwnerCategoryId { get; set; }
        public bool? IsBusinessCycle { get; set; }
        public int? BusinessCycleId { get; set; }
        public int? BusinessCycleMonth { get; set; }
        public string? BookingBranchId { get; set; }
    }

    public class LoanApplicationDataPermohonanTabUpsertRequest
    {
        public DebtorRequest Debtor { get; set; }
        public DebtorCompanyRequest DebtorCompany { get; set; }
        public DebtorCompanyLegalRequest DebtorLegalCompany { get; set; }
        public DebtorCoupleRequest? DebtorCouple { get; set; }
        public DebtorEmergencyRequest DebtorEmergency { get; set; }
    }

    public class LoanApplicationKeyPersonTabUpsertRequest
    {
        public LoanApplicationKeyPersonRequest KeyPerson { get; set; }
    }

    public class LoanApplicationDataAgunanTabUpsertRequest
    {
        public LoanApplicationCollateralRequest Collateral { get; set; }
        public LoanApplicationCollateralOwnerRequest CollateralOwner { get; set; }
    }

    public class LoanApplicationInformasiFasilitasTabUpsertRequest
    {
        public LoanApplicationFacilityRequest Facility { get; set; }
    }
}

