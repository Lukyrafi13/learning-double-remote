using NewLMS.UMKM.Data.Dto.LoanApplicationRACs;
using NewLMS.UMKM.Data.Dto.LoanApplicationSurvey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings
{
    public class LoanApplicationPrescreeningUpsertRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationRACRequest? LoanApplicationRAC { get; set; }
    }
}
