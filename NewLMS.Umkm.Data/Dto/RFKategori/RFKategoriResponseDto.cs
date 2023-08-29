using System;
namespace NewLMS.Umkm.Data.Dto.RFKategoris
{
    public class RFKategoriResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string KategoriCode { get; set; }
        public string KategoriDesc { get; set; }
        public bool Active { get; set; }
    }
}
