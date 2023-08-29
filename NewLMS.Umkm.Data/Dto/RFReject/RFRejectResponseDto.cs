using System;
namespace NewLMS.UMKM.Data.Dto.RFRejects
{
    public class RFRejectResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string RjCode { get; set; }
        public string RjDesc { get; set; }
        public string CoreCode { get; set; }
        public int? Priority { get; set; }
        public bool Active { get; set; }
    }
}
