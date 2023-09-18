using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationStageProcess
{
    public class LoanApplicationStageProcessRequest
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }

    public class LoanApplicationProcessRequest
    {
        public Guid LoanApplicationGuid { get; set; }
    }
}
