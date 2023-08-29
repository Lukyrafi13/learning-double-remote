namespace NewLMS.Umkm.Data.Dto.RFTenors
{
    public class RFTenorPostRequestDto
    {
        public string TNCode { get; set; }
        public string TNDesc { get; set; }
        public int? Tenor { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
        public string ProductId { get; set; }
    }
}
