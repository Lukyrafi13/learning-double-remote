using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfTargetStatus
{
    public class RfTargetStatusResponse : BaseResponse
    {
        public string TargetStatusCode { get; set; }
        public string TargetStatusDesc { get; set; }
        public bool Active { get; set; }
    }

    public class RfTargetStatusSimpleResponse
    {
        public string TargetStatusCode { get; set; }
        public string TargetStatusDesc { get; set; }
    }
}
