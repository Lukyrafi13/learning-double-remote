using NewLMS.Umkm.Data.Dto.RfBusinessPlaceOwnership;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationBusinessInformation : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        public bool BusinessAddressSameWithApplication { get; set; }
        
        [ForeignKey(nameof(RfBusinessLocation))]
        public string BusinessLocationCode { get; set; }

        public double? DistanceBusinessLocation { get; set; }

        [ForeignKey(nameof(RfBusinessPlaceType))]
        public string BusinessPlaceTypeCode { get; set; }


        public string PermitsHeld { get; set; }

        [ForeignKey(nameof(RfBusinessType))]
        public string BusinessTypeCode { get; set; }

        [ForeignKey(nameof(RfBusinessPlaceLocation))]
        public string BusinessPlaceLocationCode { get; set; }
        
        [ForeignKey(nameof(RfBusinessPlaceOwnership))]
        public string BusinessPlaceOwnCode { get; set; }

        public string OtherBusinessPalceOwnership { get; set; }
        public double? Number { get; set; }
        
        [ForeignKey(nameof(RfMarketingAspect))]
        public int? MarketingAspectCode { get; set; }

        [ForeignKey(nameof(RfNumberOfPermanentEmployee))]
        public int? NumberOfPermanentEmployeeCode { get; set; }

        [ForeignKey(nameof(RfNumberOfDailyEmployee))]
        public int? NumberOfDailyEmployeeCode { get; set; }
        
        public double? LongTimeInBusiness { get; set; }
        public double? LongStayBusinessPlace { get; set; }
        public bool DebtorHaveOtherBusiness { get; set; }
        public string DebtorOtherBusiness { get; set; }
        
        [ForeignKey(nameof(RfOtherBusinessDuration))]
        public int? OtherBusinessDurationCode { get; set; }

        public bool DebtorBusinessNotAvoided { get; set; }
        public string BusinessActivity { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfBusinessLocation RfBusinessLocation { get; set; }
        public virtual RfBusinessPlaceType RfBusinessPlaceType { get; set; }
        public virtual RfBusinessType RfBusinessType { get; set; }
        public virtual RfBusinessPlaceLocation RfBusinessPlaceLocation { get; set; }
        public virtual RfBusinessPlaceOwnership RfBusinessPlaceOwnership { get; set; }
        public virtual RfParameterDetail RfMarketingAspect { get; set; }
        public virtual RfParameterDetail RfNumberOfPermanentEmployee { get; set; }
        public virtual RfParameterDetail RfNumberOfDailyEmployee { get; set; }
        public virtual RfParameterDetail RfOtherBusinessDuration { get; set; }
    }
}
