using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RFSectorLBU1s
{
    public class RFSectorLBU1Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool? IsShowing { get; set; }
        public bool? HideKUR { get; set; }
    }
}
