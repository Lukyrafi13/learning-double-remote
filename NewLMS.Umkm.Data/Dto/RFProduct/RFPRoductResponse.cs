using System;
namespace NewLMS.Umkm.Data.Dto.RFProducts
{
    public class RFProductResponseDto
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ProductDesc { get; set; }
        public string ProductType { get; set; }
        public int DefTenor { get; set; }
        public int MaxTenor { get; set; }
        public string DefIntType { get; set; }
        public double DefInterest { get; set; }
        public double MinInterest { get; set; }
        public double MaxInterest { get; set; }
        public double DefProvPCTFee { get; set; }
        public double DefAdminFee { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public double MaxLimit { get; set; }
        public double LimitAppR { get; set; }
        public double MinLimit { get; set; }
    }
}
