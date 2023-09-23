using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycles;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationSurveyUpsertRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationFieldSurveyPostRequest? FieldSurvey { get; set; }
        public LoanApplicationVerificationBusinessPostRequest? LoanApplicationVerificationBusiness { get; set; }
        public LoanApplicationVerificationCyclePostRequest? LoanApplicationVerificationCycle { get; set; }
    }
}
