using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU2s
{
    public class RfSectorLBU2Response : BaseResponse
    {
        public string Code { get; set; }
        public RfSectorLBU1Response RfSectorLBU1 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
    }
}
