using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationStageProcess
{
    public class LoanApplicationStageProcessRequest
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }

    public class LoanApplicationProcessStageRequest
    {
        public Guid Id { get; set; }
    }
}
