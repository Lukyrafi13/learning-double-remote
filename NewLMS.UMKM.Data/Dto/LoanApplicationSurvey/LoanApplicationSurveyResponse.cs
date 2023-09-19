using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycles;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationSurvey
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
