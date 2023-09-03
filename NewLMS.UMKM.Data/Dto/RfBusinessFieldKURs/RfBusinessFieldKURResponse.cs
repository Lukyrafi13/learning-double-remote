using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfBusinessFieldKUR
{
    public class RfBusinessFieldKURResponse : BaseResponse
    {
        public string BusinessFieldKURCode { get; set; }
        public string BusinessFieldKURDesc { get; set; }
    }

    public class RfBusinessFieldKURSimpleResponse
    {
        public string BusinessFieldKURCode { get; set; }
        public string BusinessFieldKURDesc { get; set; }
    }
}
