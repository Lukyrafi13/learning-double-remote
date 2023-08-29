using System;
namespace NewLMS.Umkm.Data.Dto.RFSubProducts
{
    public class RFSubProductResponseDto
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        public string ProductId { get; set; }
        public RFProduct Product { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public bool? MandNPWP { get; set; }
        public string LPCode { get; set; }
    }
}
