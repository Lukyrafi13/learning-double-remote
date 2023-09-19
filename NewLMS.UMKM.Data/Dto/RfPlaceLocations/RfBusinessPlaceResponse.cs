using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfPlaceResponse
{
    public class RfBusinessPlaceResponse : BaseResponse
    {
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }

    public class RfBusinessPlaceSimpleResponse
    {
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }
}
