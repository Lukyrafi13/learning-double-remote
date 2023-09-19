using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfBusinessType
{
    public class RfBusinessTypeResponse : BaseResponse
    {
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDesc { get; set; }
    }

    public class RfBusinessTypeSimpleResponse
    {
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDesc { get; set; }
    }
}
