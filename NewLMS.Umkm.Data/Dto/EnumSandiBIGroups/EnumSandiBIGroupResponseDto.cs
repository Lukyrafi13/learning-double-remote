using System;
namespace NewLMS.Umkm.Data.Dto.EnumSandiBIGroups
{
    public class EnumSandiBIGroupResponseDto : BaseResponse
    {        
        public Guid Id { get; set; }
        public string BI_GROUP { get; set; }
        public string BI_GROUPDESC { get; set; }
    }
}
