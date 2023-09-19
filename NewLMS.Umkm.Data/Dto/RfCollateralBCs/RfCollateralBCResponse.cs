using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfCollateralBC
{
    public class RfCollateralBCResponse : BaseResponse
    {
        public string CollateralCode { get; set; }
        public string CollateralDesc { get; set; }
        public string CollateralType { get; set; }
        public bool Land { get; set; }
        public bool Building { get; set; }
        public string BeaGroup { get; set; }
        public string ColllatealCatCode { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfCollateralBCSimpleResponse
    {
        public string CollateralCode { get; set; }
        public string CollateralDesc { get; set; }
    }
}
