using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfVehType
{
    public class RfVehTypeResponse : BaseResponse
    {
        public int VehCode { get; set; }
        public string VehDesc { get; set; }
        public int CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfVehTypeSimpleResponse
    {
        public int VehCode { get; set; }
        public string VehDesc { get; set; }
    }
}
