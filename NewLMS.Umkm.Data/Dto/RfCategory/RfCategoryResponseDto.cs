using System;
namespace NewLMS.UMKM.Data.Dto.RfCategories
{
    public class RfCategoryResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDesc { get; set; }
        public bool Active { get; set; }
    }
}
