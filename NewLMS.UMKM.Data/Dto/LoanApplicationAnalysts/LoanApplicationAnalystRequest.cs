using NewLMS.Umkm.Data.Dto.LoanApplicationBusinessInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts
{
    public class LoanApplicationAnalystRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationBusinessInformationRequest LoanApplicationBusinessInformation { get; set; }
    }
}
