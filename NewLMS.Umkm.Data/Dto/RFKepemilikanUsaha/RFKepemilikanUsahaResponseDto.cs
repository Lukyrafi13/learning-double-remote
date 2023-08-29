using System;
namespace NewLMS.UMKM.Data.Dto.RFKepemilikanUsahas
{
    public class RFKepemilikanUsahaResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string KepemilikanUsahaId { get; set; }
        public string KepemilikanUsahaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
