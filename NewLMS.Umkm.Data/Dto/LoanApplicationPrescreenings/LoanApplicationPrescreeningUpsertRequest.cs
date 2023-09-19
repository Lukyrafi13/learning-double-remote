using NewLMS.Umkm.Data.Dto.LoanApplicationRACs;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings
{
    public class LoanApplicationPrescreeningUpsertRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationRACRequest? LoanApplicationRAC { get; set; }
    }
}
