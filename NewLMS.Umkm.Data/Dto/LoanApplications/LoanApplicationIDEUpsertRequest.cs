using System;
using NewLMS.Umkm.Data.Dto.Debtor;
using NewLMS.Umkm.Data.Dto.DebtorCompany;
using NewLMS.Umkm.Data.Dto.DebtorCompanyLegal;
using NewLMS.Umkm.Data.Dto.DebtorCouple;
using NewLMS.Umkm.Data.Dto.DebtorEmergencies;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditScorings;

#nullable enable
namespace NewLMS.Umkm.Data.Dto.LoanApplications
{
    public class LoanApplicationIDEUpsertRequest
    {
        public Guid AppId { get; set; }
        public string Tab { get; set; }
        public int OwnerCategoryId { get; set; }
        public string? DecisionMakerCode { get; set; }
        public LoanApplicationInitialDataEntryTabUpsertRequest? InitialDataEntry { get; set; }
        public LoanApplicationDataPermohonanTabUpsertRequest? DataPermohonan { get; set; }
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
        public DebtorRequest? Debtor { get; set; }
        public DebtorCoupleRequest? DebtorCouple { get; set; }
        public DebtorCompanyRequest? DebtorCompany { get; set; }
        public DebtorCompanyLegalRequest? DebtorCompanyLegal { get; set; }
        public DebtorEmergencyRequest? DebtorEmergency { get; set; }
    }

    //public class LoanApplicationKeyPersonTabUpsertRequest
    //{
    //    public LoanApplicationKeyPersonRequest KeyPerson { get; set; }
    //}

    //public class LoanApplicationDataAgunanTabUpsertRequest
    //{
    //    public LoanApplicationCollateralRequest Collateral { get; set; }
    //    public LoanApplicationCollateralOwnerRequest CollateralOwner { get; set; }
    //}

    //public class LoanApplicationInformasiFasilitasTabUpsertRequest
    //{
    //    public LoanApplicationFacilityRequest Facility { get; set; }
    //}
}

