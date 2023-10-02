using NewLMS.Umkm.Data.Dto.LoanApplicationRACs;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings
{
    public class LoanApplicationPrescreeningUpsertRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationRACRequest? LoanApplicationRAC { get; set; }
        public LoanApplicationPrescreeningDuplicationRequest Duplication { get; set; }
    }

    public class LoanApplicationPrescreeningDuplicationRequest
    {
        public bool DuplicationsVerified { get; set; }
    }

}
