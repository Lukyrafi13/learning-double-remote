using System;
namespace NewLMS.UMKM.Data.Dto.RfAppTypes
{
    public class RfAppTypeResponseDto : BaseResponse
    {
		public Guid Id { get; set; }
		public string Type { get; set; }
    }
}
