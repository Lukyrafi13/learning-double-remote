using System;
namespace NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs
{
    public class RFBidangUsahaKURResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string BTCode { get; set; }
        public string BTDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
