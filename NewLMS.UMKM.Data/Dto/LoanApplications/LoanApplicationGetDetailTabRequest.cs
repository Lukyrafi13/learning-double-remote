using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationGetDetailTabRequest
    {
        public Guid Id { get; set; }
        public string Tab { get; set; } = "initial_data_entry";
    }

    public class LoanApplicationGetPrescreeningDetailTabRequest
    {
        public Guid Id { get; set; }
        public string Tab { get; set; }
    }

    public class LoanApplicationGetDetailRequests
    {
        public Guid Id { get; set; }
    }

    public class LoanApplicationApprGetDetailRequests
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }

    public class LoanApplicationApprAppInfoRequests
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class LoanApplicationApprSurveyorGetDetailRequests
    {
        public Guid LoanApplicationCollateralId { get; set; }
        public string Tab { get; set; }
    }
}

