using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfCreditNature
{
    public class RfCreditNatureResponse : BaseResponse
    {
        public string CreditNatureCode { get; set; }
        public string CreditNatureDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfCreditNatureSimpleResponse
    {
        public string CreditNatureCode { get; set; }
        public string CreditNatureDesc { get; set; }
    }
}
