using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto
{
    public class RfBusinessPlaceLocationResponse : BaseResponse
    {
        public string RfBusinessPlaceLocationCode { get; set; }
        public string RfBusinessPlaceLocationDesc { get; set; }
    }

    public class RfBusinessPlaceLocationSimpleResponse
    {
        public string RfBusinessPlaceLocationCode { get; set; }
        public string RfBusinessPlaceLocationDesc { get; set; }
    }
}
