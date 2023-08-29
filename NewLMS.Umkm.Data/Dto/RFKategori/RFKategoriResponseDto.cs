using System;
namespace NewLMS.UMKM.Data.Dto.RfCategorys
{
    public class RfCategoryResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string KategoriCode { get; set; }
        public string KategoriDesc { get; set; }
        public bool Active { get; set; }
    }
}
