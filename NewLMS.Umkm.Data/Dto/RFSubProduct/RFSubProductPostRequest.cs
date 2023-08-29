namespace NewLMS.UMKM.Data.Dto.RFSubProducts
{
    public class RFSubProductPostRequestDto
    {
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        public string ProductId { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public bool? MandNPWP { get; set; }
        public string LPCode { get; set; }
        public string SIKPSkema { get; set; }
        public string SIKPParentSkema { get; set; }
    }
}
