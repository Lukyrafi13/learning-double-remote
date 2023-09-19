using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfBusinessPlaceOwnership
{
    public class RfBusinessPlaceOwnershipResponse : BaseResponse
    {
        public string BusinessPlaceOwnCode { get; set; }
        public string BusinessPlaceOwnDesc { get; set; }
        public RfBusinessPlaceLocationSimpleResponse RfBusinessPlaceLocation { get; set; }
    }

    public class RfBusinessPlaceOwnershipSimpleResponse
    {
        public string BusinessPlaceOwnCode { get; set; }
        public string BusinessPlaceOwnDesc { get; set; }
    }
}
