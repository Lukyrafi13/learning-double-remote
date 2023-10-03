using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.Debtor;
using NewLMS.Umkm.Data.Dto.DebtorCompany;
using NewLMS.Umkm.Data.Dto.LoanApplicationRACs;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Dto.RfProducts;
using NewLMS.Umkm.Data.Dto.Users;
using NewLMS.Umkm.Data.Enums;
using System;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings
{
    public class LoanApplicationPrescreeningsTableResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public DateTime RequestDate { get; set; }
        public string SlikStatus { get; set; }
        public string DebtorName { get; set; }
        public DateTime DebtorDateOfBirth { get; set; }

    }

    public class LoanApplicationPrescreeningResponse
    {
        public Guid Id { get; set; }
        public LoanApplicationPrescreeningInfoResponse InfoPrescreening { get; set; }
        public LoanApplicationRACsResponse? LoanApplicationRAC { get; set; }
        public List<LoanApplicationCollateralPrescreeningResponse>? LoanApplicationCollaterals { get; set; }
        public LoanApplicationPrescreeningSLIKAdminTabResponse? SLIKAdmin { get; set; }
    }

    public class LoanApplicationPrescreeningSLIKAdminTabResponse
    {
        public List<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }
        public List<LoanApplicationCreditHistoryResponse> CreditHistories { get; set; }
    }

    public class LoanApplicationPrescreeningBaseTabReponse
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
        public Guid? OwnerId { get; set; }
        public bool DuplicationsVerified { get; set; }

        public RfParameterDetailSimpleResponse RfOwnerCategory { get; set; }
        public RfBranchResponse RfBranch { get; set; }
        public RfBranchResponse RfBookingBranch { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public UserSimpleResponse Owner { get; set; }
        public DebtorResponse Debtor { get; set; }
        public DebtorCompanyResponse DebtorCompany { get; set; }
    }
}
