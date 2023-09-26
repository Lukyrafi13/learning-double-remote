using NewLMS.Umkm.Data.Dto.RfSectorLBU1s;

namespace NewLMS.Umkm.Data.Dto.RfSectorLBU2s
{
    public class RfSectorLBU2Response : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public string LBCode1 { get; set; }
        public RfSectorLBU1Response RfSectorLBU1 { get; set; }
    }
}
