using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RFSectorLBU2s
{
    public class RFSectorLBU2Response : BaseResponse
    {
        public string Code { get; set; }
        public RFSectorLBU1Response RFSectorLBU1 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
    }
}
