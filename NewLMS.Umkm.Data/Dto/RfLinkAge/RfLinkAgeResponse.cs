using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfLinkAge
{
    public class RfLinkAgeResponse : BaseResponse
    {
        public string LinkAgeTypeCode { get; set; }
        public string LinkAgeTypeDesc { get; set; }
    }

    public class RfLinkAgeSimpleResponse
    {
        public string LinkAgeTypeCode { get; set; }
        public string LinkAgeTypeDesc { get; set; }
    }
}
