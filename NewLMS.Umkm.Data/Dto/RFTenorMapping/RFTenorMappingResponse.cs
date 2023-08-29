using System;
namespace NewLMS.Umkm.Data.Dto.RFTenorMappings
{
    public class RFTenorMappingResponseDto
    {
        public Guid Id { get; set; }
        public string TNCode { get; set; }
        public string SiklusCode { get; set; }
        public string ProductId { get; set; }
        public RFProduct Product { get; set; }
    }
}
