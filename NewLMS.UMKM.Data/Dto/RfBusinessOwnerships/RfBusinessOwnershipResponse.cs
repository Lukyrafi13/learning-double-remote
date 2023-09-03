using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfBusinessOwnership
{
    public class RfBusinessOwnershipResponse : BaseResponse
    {
        public string BusinessOwnershipCode { get; set; }
        public string BusinessOwnershipDesc { get; set; }
    }

    public class RfBusinessOwnershipSimpleResponse
    {
        public string BusinessOwnershipCode { get; set; }
        public string BusinessOwnershipDesc { get; set; }
    }
}
