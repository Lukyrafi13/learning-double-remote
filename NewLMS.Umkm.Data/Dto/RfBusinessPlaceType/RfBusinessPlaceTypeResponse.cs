using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfBusinessPlaceType
{
    public class RfBusinessPlaceTypeResponse : BaseResponse
    {
        public string BusinessPlaceTypeCode { get; set; }
        public string BusinessPlaceTypeDesc { get; set; }
    }

    public class RfBusinessPlaceTypeSimpleResponse
    {
        public string BusinessPlaceTypeCode { get; set; }
        public string BusinessPlaceTypeDesc { get; set; }
    }
}
