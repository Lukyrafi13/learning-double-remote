using System;
namespace NewLMS.UMKM.Data.Dto.RFTenors
{
    public class RFTenorResponseDto
    {
        public Guid Id { get; set; }
        public string TNCode { get; set; }
        public string TNDesc { get; set; }
        public string Tenor { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
        public string ProductId { get; set; }
    }
}
