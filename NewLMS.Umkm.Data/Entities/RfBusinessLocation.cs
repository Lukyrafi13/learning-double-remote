using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfBusinessLocation : BaseEntity
    {
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }
}
