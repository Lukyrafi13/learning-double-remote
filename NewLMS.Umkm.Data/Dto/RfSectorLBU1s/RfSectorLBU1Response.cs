using System;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Dto.RfGenders;
using NewLMS.Umkm.Data.Dto.RfProducts;

namespace NewLMS.Umkm.Data.Dto.RfSectorLBU1s
{
    public class RfSectorLBU1Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool HideKUR { get; set; }
    }
}
