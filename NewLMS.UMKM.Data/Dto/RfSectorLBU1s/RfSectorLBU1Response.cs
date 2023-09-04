using System;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfProducts;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU1s
{
    public class RfSectorLBU1Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool HideKUR { get; set; }
    }
}
