using System;
namespace NewLMS.Umkm.Data.Dto.RFInsRateMappings
{
    public class RFInsRateMappingPostRequestDto
    {
        public string InsRateId { get; set; }
        public string TPLCode { get; set; }
        public string ProductId { get; set; }
        public string SubProductId { get; set; }
        public string JobCode { get; set; }
        public int? MinTenor { get; set; }
        public int? MaxTenor { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int? TplPrio { get; set; }
        public double? InsRate { get; set; }
        public string InsTypeId { get; set; }
        public string CompId { get; set; }
        public bool? Active { get; set; }
    }
}
