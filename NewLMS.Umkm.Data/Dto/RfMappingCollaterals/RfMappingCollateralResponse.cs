using NewLMS.Umkm.Data.Dto.RfCollateralBC;
using NewLMS.Umkm.Data.Dto.RfProducts;
using System;

namespace NewLMS.Umkm.Data.Dto.RfMappingCollateral
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
