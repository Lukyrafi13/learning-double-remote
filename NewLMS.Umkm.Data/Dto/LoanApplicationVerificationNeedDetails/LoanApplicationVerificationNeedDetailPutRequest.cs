using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails
{
    public class LoanApplicationVerificationNeedDetailPutRequest
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string NeedsDetail { get; set; }
        public string Description { get; set; }
        public double? Total { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public double? TotalPrice { get; set; }
    }
}
