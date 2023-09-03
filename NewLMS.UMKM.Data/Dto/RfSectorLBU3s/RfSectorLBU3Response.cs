using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;

namespace NewLMS.UMKM.Data.Dto.RfSectorLBU3s
{
    public class RfSectorLBU3Response : BaseResponse
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public int Group { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public string CategoryCode { get; set; }
        public RfSectorLBU2Response RfSectorLBU2 { get; set; }
    }
}
