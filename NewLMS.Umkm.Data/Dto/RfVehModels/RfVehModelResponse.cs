using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfVehModel
{
    public class RfVehModelResponse : BaseResponse
    {
        public string VehModelCode { get; set; }
        public string VehModelDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfVehModelSimplelResponse
    {
        public string VehModelCode { get; set; }
        public string VehModelDesc { get; set; }
    }
}
