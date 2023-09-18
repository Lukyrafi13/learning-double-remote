using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationCycles;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationSurveyResponse
    {
        public LoanApplicationAppInfoApprSurveyorResponse LoanApplicationInfo { get; set; }
        public LoanApplicationFieldSurveyResponse? LoanApplicationFieldSurvey { get; set; }
        public LoanApplicationVerificationBusinessResponse? LoanApplicationVerificationBusiness { get; set; }
        public LoanApplicationVerificationCycleResponse? LoanApplicationVerificationCycle { get; set; }
    }

    public class LoanApplicationSurveyTabRespone
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public DateTime RequestDate { get; set; }
        public string SlikStatus { get; set; }
        public string DebtorName { get; set; }
        public DateTime? DebtorDateOfBirth { get; set; }
    }
}
