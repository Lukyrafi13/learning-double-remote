using System;

namespace NewLMS.UMKM.Data.Dto.RFSubProductInts
{
    public class RFSubProductIntPostRequestDto
    {
        public string TPLCode { get; set; }
        public string ProductId { get; set; }
        public string SubProductId { get; set; }
        public string AppType { get; set; }
        public double? MinPlafon { get; set; }
        public double? MaxPlafon { get; set; }
        public int? MinTenor { get; set; }
        public int? MaxTenor { get; set; }
        public string BranchId { get; set; }
        public int? TPLPrio { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string IntType { get; set; }
        public double? Interest { get; set; }
        public double? ProvPCT { get; set; }
        public double? AdminFee { get; set; }
        public double? InterestEff { get; set; }
        public string BaseRate { get; set; }
        public double? ParamSpread { get; set; }
        public int? BaseRateYear { get; set; }
        public bool? Active { get; set; }
        public string CoreProvCode { get; set; }
    }
}
