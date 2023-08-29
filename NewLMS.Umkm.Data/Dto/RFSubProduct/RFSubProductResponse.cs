using System;
namespace NewLMS.UMKM.Data.Dto.RFSubProducts
{
    public class RFSubProductResponseDto
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        public string ProductId { get; set; }
        public RfProduct Product { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public bool? MandNPWP { get; set; }
        public string LPCode { get; set; }
    }
}
