using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfCreditType
{
    public class RfCreditTypeResponse : BaseResponse
    {
        public string CreditTypeCode { get; set; }
        public string CreditTypeDesc { get; set; }
        public bool? CreditAgreement { get; set; }
    }

    public class RfCreditTypeSimpleResponse
    {
        public string CreditTypeCode { get; set; }
        public string CreditTypeDesc { get; set; }
        public bool? CreditAgreement { get; set; }
    }
}
