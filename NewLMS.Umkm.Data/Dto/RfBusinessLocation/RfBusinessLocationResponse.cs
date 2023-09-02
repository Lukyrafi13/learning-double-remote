using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfBusinessLocation
{
    public class RfBusinessLocationResponse : BaseResponse
    {
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }
    public class RfBusinessLocationSimpleResponse
    {
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }
}
