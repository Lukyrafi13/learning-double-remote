using System;
namespace NewLMS.UMKM.Data.Dto.RFTenorMappings
{
    public class RFTenorMappingResponseDto
    {
        public Guid Id { get; set; }
        public string TNCode { get; set; }
        public string SiklusCode { get; set; }
        public string ProductId { get; set; }
        public RfProduct Product { get; set; }
    }
}
