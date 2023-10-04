using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationBusinessInformations
{
    public class LoanApplicationBusinessInformationRequest
    {
        public Guid LoanApplicationId { get; set; }
        public bool BusinessAddressSameWithApplication { get; set; }
        public string BusinessLocationCode { get; set; }
        public double? DistanceBusinessLocation { get; set; }
        public string BusinessPlaceTypeCode { get; set; }
        public string PermitsHeld { get; set; }
        public string BusinessTypeCode { get; set; }
        public string BusinessPlaceLocationCode { get; set; }
        public string BusinessPlaceOwnCode { get; set; }
        public string OtherBusinessPalceOwnership { get; set; }
        public double? Number { get; set; }
        public int? MarketingAspectCode { get; set; }
        public int? NumberOfPermanentEmployeeCode { get; set; }
        public int? NumberOfDailyEmployeeCode { get; set; }
        public double? LongTimeInBusiness { get; set; }
        public double? LongStayBusinessPlace { get; set; }
        public bool DebtorHaveOtherBusiness { get; set; }
        public string DebtorOtherBusiness { get; set; }
        public int? OtherBusinessDurationCode { get; set; }
        public bool DebtorBusinessNotAvoided { get; set; }
        public string BusinessActivity { get; set; }
    }
}
