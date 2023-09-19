using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfLoanPurpose
{
    public class RfLoanPurposeResponse : BaseResponse
    {
        public string LoanPurposeCode { get; set; }
        public string LoanPurposeDesc { get; set; }
        public int? MaxProd { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfLoanPurposeSimpleResponse
    {
        public string LoanPurposeCode { get; set; }
        public string LoanPurposeDesc { get; set; }
    }
}
