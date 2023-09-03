using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfVehCountry
{
    public class RfVehCountryResponse : BaseResponse
    {
        public string VehCountryCode { get; set; }
        public string VehCountryDesc { get; set; }
        public string CoreCode { get; set; }
        public string Active { get; set; }
    }

    public class RfVehCountrySimpleResponse
    {
        public string VehCountryCode { get; set; }
        public string VehCountryDesc { get; set; }
    }
}
