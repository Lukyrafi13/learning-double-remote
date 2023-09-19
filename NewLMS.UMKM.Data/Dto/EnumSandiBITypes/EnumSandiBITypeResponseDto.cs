using System;
namespace NewLMS.Umkm.Data.Dto.EnumSandiBITypes
{
    public class EnumSandiBITypeResponseDto : BaseResponse
    {        
        public Guid Id { get; set; }
        public string BI_TYPE { get; set; }
        public string BI_TYPEDESC { get; set; }
    }
}
