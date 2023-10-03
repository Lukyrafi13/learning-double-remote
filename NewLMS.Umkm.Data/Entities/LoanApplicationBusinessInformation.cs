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
        public string BusinessAddressSameWithApplication { get; set; }
        public string BusinessLocation { get; set; }
        public double? DistanceBusinessLocation { get; set; }
        public string BusinessPlaceType { get; set; }
        public string PermitsHeld { get; set; }
        public string BusinessGroup { get; set; }
        public string BusinessPlaceLocation { get; set; }
        public string Ownership { get; set; }
        public double? Number { get; set; }
        public string MarketingAspect { get; set; }
        public string NumberOfPermanentEmployee { get; set; }
        public string NumberOfDailyEmployee { get; set; }
        public double? LongTimeInBusiness { get; set; }
        public double? LongStayBusinessPlace { get; set; }
        public string DebtorHaveOtherBusiness { get; set; }
        //kayanya ada tambahan field disini
        public string DebtorBusinessNotAvoided { get; set; }
        public string BusinessActivity { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
    }
}
