using NewLMS.Umkm.Data.Dto.RfBusinessLocation;
using NewLMS.Umkm.Data.Dto.RfBusinessPlaceOwnership;
using NewLMS.Umkm.Data.Dto.RfBusinessPlaceType;
using NewLMS.Umkm.Data.Dto.RfBusinessType;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Entities;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationBusinessInformations
{
    public class LoanApplicationBusinessInformationResponse : BaseResponse
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

        public RfBusinessLocationSimpleResponse RfBusinessLocation { get; set; }
        public RfBusinessPlaceTypeSimpleResponse RfBusinessPlaceType { get; set; }
        public RfBusinessTypeSimpleResponse RfBusinessType { get; set; }
        public RfBusinessPlaceLocationSimpleResponse RfBusinessPlaceLocation { get; set; }
        public RfBusinessPlaceOwnershipSimpleResponse RfBusinessPlaceOwnership { get; set; }
        public RfParameterDetailSimpleResponse RfMarketingAspect { get; set; }
        public RfParameterDetailSimpleResponse RfNumberOfPermanentEmployee { get; set; }
        public RfParameterDetailSimpleResponse RfNumberOfDailyEmployee { get; set; }
        public RfParameterDetailSimpleResponse RfOtherBusinessDuration { get; set; }
    }
}
