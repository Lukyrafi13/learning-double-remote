using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Dto.RfProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfMappingCollateral
{
    public class RfMappingCollateralResponse : BaseResponse
    {
        public Guid MappingCollateralId { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public RfCollateralBCSimpleResponse RfCollateralBC { get; set; }
        public bool Active { get; set; }
    }

    public class RfMappingCollateralSimpleResponse
    {
        public Guid MappingCollateralId { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public RfCollateralBCSimpleResponse RfCollateralBC { get; set; }
    }
}
