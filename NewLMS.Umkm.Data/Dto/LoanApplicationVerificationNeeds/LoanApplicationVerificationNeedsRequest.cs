using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeeds
{
    public class LoanApplicationVerificationNeedsRequest
    {
        public Guid LoanApplicationId { get; set; }
        public string PPTKISName { get; set; }
        public double? LongPlacementTime { get; set; }
        public double? ExtendtedTime { get; set; }
        public string BirthCertificateNumber { get; set; }
        public double? MonthlyIncomeForeignCurrency { get; set; }
        public double? ExchangeRate { get; set; }
        public double? MonthlyIncomeRupiahCurrency { get; set; }
        public string PassportNumber { get; set; }
        public string VisaNumber { get; set; }
    }
}
