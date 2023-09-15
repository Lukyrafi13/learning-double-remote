using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Dto.LoanApplications;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class AppraisalSurveyorResponse
    {
        public LoanApplicationAppInfoApprResponse LoanApplicationInfo { get; set; }
        public LoanApplicationCollateralResponse LoanApplicationCollateral { get; set; }
    }
}
