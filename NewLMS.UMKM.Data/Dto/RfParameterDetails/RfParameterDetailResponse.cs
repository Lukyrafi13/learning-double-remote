using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Data.Dto;

namespace NewLMS.Umkm.Data.Dto.RfParameterDetails
{
    public class RfParameterDetailResponse : BaseResponse
    {
        public int ParameterDetailId { get; set; }
        public int ParameterId { get; set; }
        public string Code { get; set; }
        public string CoreCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public RfParameterResponse RfParameter { get; set; }
    }

    public class RfParameterDetailSimpleResponse
    {
        public int ParameterDetailId { get; set; }
        public string Description { get; set; }
    }
}
