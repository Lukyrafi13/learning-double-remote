using NewLMS.Umkm.Data.Dto.RfCollateralBC;
using NewLMS.Umkm.Data.Dto.RfVehCountry;
using NewLMS.Umkm.Data.Dto.RfVehType;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfVehMaker
{
    public class RfVehMakerResponse : BaseResponse
    {
        public string VehMakerCode { get; set; }
        public string VehmakerDesc { get; set; }
        public RfVehTypeSimpleResponse RfVehType { get; set; }
        public RfVehCountrySimpleResponse RfVehCountry { get; set; }
        public RfCollateralBCResponse RfCollateralBC { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfVehMakerSimpleResponse
    {
        public string VehMakerCode { get; set; }
        public string VehmakerDesc { get; set; }
    }
}
