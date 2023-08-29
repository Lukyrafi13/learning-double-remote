using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU3s
{
    public class RfSectorLBU3Response : BaseResponse
    {
        public string Code { get; set; }
        public RfSectorLBU2Response RfSectorLBU2 { get; set; }
        public string Type { get; set; }
        public int Group { get; set; }
        public string LBCode2 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public string CategoryCode { get; set; }
        public string RfSectorLBU2Code { get; set; }
    }
}
