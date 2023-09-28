using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfPlacementCountry;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeeds
{
    public class LoanApplicationVerificationNeedsResponse : BaseResponse
    {
        public Guid LoanApplicationId { get; set; }
        public string PPTKISName { get; set; }
        public string PlaceMentCountryCode { get; set; }
        public double? LongPlacementTime { get; set; }
        public double? ExtendtedTime { get; set; } 
        public int? ApplicationTypeCode { get; set; }
        public string BirthCertificateNumber { get; set; }
        public double? MonthlyIncomeForeignCurrency { get; set; }
        public double? ExchangeRate { get; set; }
        public double? MonthlyIncomeRupiahCurrency { get; set; }
        public string PassportNumber { get; set; }
        public string VisaNumber { get; set; }

        public virtual RfPlacementCountrySimpleResponse RfPlacementCountry { get; set; }
        public virtual RfParameterDetailSimpleResponse ApplicationType { get; set; }
    }
}
