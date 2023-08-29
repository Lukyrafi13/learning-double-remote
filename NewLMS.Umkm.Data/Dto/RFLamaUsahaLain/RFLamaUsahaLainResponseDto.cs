using System;
namespace NewLMS.Umkm.Data.Dto.RFLamaUsahaLains
{
    public class RFLamaUsahaLainResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string ANLCode { get; set; }
        public string ANLDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
