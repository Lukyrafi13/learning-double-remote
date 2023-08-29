using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RFSectorLBU3s
{
    public class RFSectorLBU3Response : BaseResponse
    {
        public string Code { get; set; }
        public RFSectorLBU2Response RFSectorLBU2 { get; set; }
        public string Type { get; set; }
        public int Group { get; set; }
        public string LBCode2 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public string CategoryCode { get; set; }
        public string RFSectorLBU2Code { get; set; }
    }
}
