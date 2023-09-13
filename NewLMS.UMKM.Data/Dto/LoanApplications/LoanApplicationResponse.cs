using System;
using NewLMS.UMKM.Data.Enums;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.Debtor;
using NewLMS.UMKM.Data.Dto.DebtorCompany;
using NewLMS.UMKM.Data.Dto.DebtorEmergencies;
using System.Collections.Generic;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditScoring;
using NewLMS.UMKM.Data.Dto.Users;
using NewLMS.UMKM.Data.Dto.Prospects;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationResponse : BaseResponse
    {
    }

    public class LoanApplicationIDEResponse
    {
        public LoanApplicationBaseTabResponse Info { get; set; }
        public LoanApplicationDataFasilitasTabResponse? InitialData { get; set; }
        public LoanApplicationDataPermohonanTabResponse? DataPermohonan { get; set; }
        public LoanApplicationDataKeyPersonTabResponse? KeyPerson { get; set; }
        public LoanApplicationDataAgunanTabResponse? DataAgunan { get; set; }
        public LoanApplicationInformasiFasilitasTabResponse? InformasiFasilitas { get; set; }
    }

    public class LoanApplicationDataFasilitasTabResponse
    {
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public RfParameterDetailResponse RfBusinessCycle { get; set; }
        public int? BusinessCycleMonth { get; set; }
        public RfProductResponse RfProduct { get; set; }
        public RfBranchResponse RfBranch { get; set; }
        public RfBranchResponse RfBookingBranch { get; set; }
        public LoanApplicationCreditScoringResponse? loanApplicationCreditScoring { get; set; }
    }

    public class LoanApplicationDataPermohonanTabResponse
    {
        public DebtorResponse Debtor { get; set; }
        public DebtorCompanyResponse DebtorCompany { get; set; }
        public DebtorEmergencyResponse DebtorEmergency { get; set; }
    }

    public class LoanApplicationDataKeyPersonTabResponse
    {
        public List<LoanApplicationKeyPersonResponse> LoanApplicationKeyPersons { get; set; }
    }

    public class LoanApplicationDataAgunanTabResponse
    {
        public List<LoanApplicationCollateralResponse> LoanApplicationCollaterals { get; set; }
    }

    public class LoanApplicationInformasiFasilitasTabResponse
    {
        public List<LoanApplicationFacilityResponse> LoanApplicationFacilities { get; set; }
    }

    public class LoanApplicationTableResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public string DebtorName { get; set; }
        public string ProductName { get; set; }
        public string OwnerCategory { get; set; }
        public string DataSource { get; set; }
    }

    public class LoanApplicationBaseTabResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public Guid StageId { get; set; }
        public EnumLoanApplicationStatus Status { get; set; }
        public string DataSource { get; set; }
        public string ProductId { get; set; }
        public Guid? ProspectId { get; set; }
        public int OwnerCategoryId { get; set; }
        public bool IsBusinessCycle { get; set; }
        public string BranchId { get; set; }
        public string BookingBranchId { get; set; }
        public string FullName { get; set; }
        public Guid? OwnerId { get; set; }

        public RfParameterDetailSimpleResponse RfOwnerCategory { get; set; }
        public RfBranchResponse RfBranch { get; set; }
        public RfBranchResponse RfBookingBranch { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public UserSimpleResponse Owner { get; set; }
        public ProspectEstimatedDateResponse Prospect { get; set; }
    }
}


