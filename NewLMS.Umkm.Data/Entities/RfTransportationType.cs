using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfTransportationType : BaseEntity
    {
        public string TransportationTypeCode { get; set; }
        public string TransportationTypeDesc { get; set; }
    }
}
