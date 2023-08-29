using System;

namespace NewLMS.UMKM.Data.Dto.RFTenorMappings
{
    public class RFTenorMappingPutRequestDto : RFTenorMappingPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
