using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfLinkAgeType
{
    public class RfLinkAgeTypeResponse : BaseResponse
    {
        public string LinkAgeTypeCode { get; set; }
        public string LinkAgeTypeDesc { get; set; }
    }

    public class RfLinkAgeTypeSimpleResponse
    {
        public string LinkAgeTypeCode { get; set; }
        public string LinkAgeTypeDesc { get; set; }
    }
}
