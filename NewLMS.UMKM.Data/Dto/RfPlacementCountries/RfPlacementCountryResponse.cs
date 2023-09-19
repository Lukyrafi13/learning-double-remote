using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfPlacementCountry
{
    public class RfPlacementCountryResponse : BaseResponse
    {
        public string PlacementCountryCode { get; set; }
        public string PlacementCountryDesc { get; set; }
        public double? Kurs { get; set; }
        public bool? ShowKUR { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
    }

    public class RfPlacementCountrySimpleResponse
    {
        public string PlacementCountryCode { get; set; }
        public string PlacementCountryDesc { get; set; }
    }
}
