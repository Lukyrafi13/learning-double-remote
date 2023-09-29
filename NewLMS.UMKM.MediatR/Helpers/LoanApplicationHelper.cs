using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Helpers
{
    public static class LoanApplicationHelper
    {
        public static LoanApplication ClearLoanApplicationRelatives(LoanApplication loanApplication)
        {
            loanApplication.RfBookingBranch = null;
            loanApplication.RfBranch = null;
            loanApplication.RfBusinessCycle = null;
            loanApplication.RfOwnerCategory = null;
            loanApplication.RfProduct = null;
            loanApplication.RfSectorLBU3 = null;
            loanApplication.RfStage = null;
            loanApplication.DecisionMaker = null;
            loanApplication.LoanApplicationFacilities = null;
            loanApplication.Debtor = null;
            loanApplication.DebtorCompany = null;
            loanApplication.LoanApplicationCreditScoring = null;
            loanApplication.LoanApplicationCollaterals = null;
            loanApplication.LoanApplicationFieldSurvey = null;
            loanApplication.LoanApplicationKeyPersons = null;
            loanApplication.LoanApplicationRAC = null;
            loanApplication.LoanApplicationStages = null;
            loanApplication.LoanApplicationVerificationBusiness = null;
            loanApplication.LoanApplicationVerificationCycle = null;
            loanApplication.LoanApplicationVerificationNeed = null;
            loanApplication.Prospect = null;

            return loanApplication;
        }
    }
}

