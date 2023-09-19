using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Dto.LoanApplications;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class AppraisalSurveyorResponse
    {
        public LoanApplicationAppInfoApprResponse LoanApplicationInfo { get; set; }
        public LoanApplicationCollateralResponse LoanApplicationCollateral { get; set; }
    }
}
