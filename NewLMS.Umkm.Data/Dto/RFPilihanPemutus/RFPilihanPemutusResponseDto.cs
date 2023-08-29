using System;
namespace NewLMS.UMKM.Data.Dto.RFPilihanPemutuss
{
    public class RFPilihanPemutusResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string PemCode { get; set; }
        public string PemDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
