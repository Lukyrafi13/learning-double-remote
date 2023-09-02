using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfBusinessOwnership : BaseEntity
    {
        public string BusinessOwnershipCode { get; set; }
        public string BusinessOwnershipDesc { get; set; }
    }
}
