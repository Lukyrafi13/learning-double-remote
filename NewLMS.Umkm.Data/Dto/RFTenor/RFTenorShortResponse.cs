using System;
namespace NewLMS.UMKM.Data.Dto.RFTenors
{
    public class RFTenorShortResponseDto
    {
        public string TNCode { get; set; }
        public string TNDesc { get; set; }
        public int? Tenor { get; set; }
        public string CoreCode { get; set; }
    }
}
