using System;
using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.RFTenors;

namespace NewLMS.Umkm.Data.Dto.RFSubProductTenors
{
    public class RFSubProductTenorDetailResponseDto
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set; }
        public List<RFTenorShortResponseDto> Tenors { get; set; } = new List<RFTenorShortResponseDto>();
    }
}
