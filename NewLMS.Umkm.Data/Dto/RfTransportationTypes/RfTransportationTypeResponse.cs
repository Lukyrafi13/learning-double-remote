using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfTransportationType
{
    public class RfTransportationTypeResponse : BaseResponse
    {
        public string TransportationTypeCode { get; set; }
        public string TransportationTypeDesc { get; set; }
    }

    public class RfTransportationTypeSimpleResponse
    {
        public string TransportationTypeCode { get; set; }
        public string TransportationTypeDesc { get; set; }
    }
}
