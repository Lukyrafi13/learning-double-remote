using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU1s
{
    public class RfSectorLBU1Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool? IsShowing { get; set; }
        public bool? HideKUR { get; set; }
    }
}
