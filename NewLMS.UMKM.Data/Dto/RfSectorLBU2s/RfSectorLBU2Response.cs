using System;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU2s
{
    public class RfSectorLBU2Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public RfSectorLBU1Response RfSectorLBU1 { get; set; }
    }
}
