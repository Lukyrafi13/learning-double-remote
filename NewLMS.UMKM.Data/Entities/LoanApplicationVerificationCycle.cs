using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationVerificationCycle : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey(nameof(LoanApplication))]
        public Guid Id { get; set; }

        //Informasi Omset
        [ForeignKey(nameof(BusinessLandForm))]
        public int? BusinessLandFormCode { get; set; }

        [ForeignKey(nameof(BusinessLandArea))]
        public int? BusinessLandAreaCode { get; set; }

        public double LandArea { get; set; }

        [ForeignKey(nameof(BusinessCapacity))]
        public int? BusinessCapacityCode { get; set; }
        
        public double BusinessLandCapacity { get; set; }

        public double AnnualSales { get; set; }
        public double NetWorthOfPlaceBusiness { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfParameterDetail BusinessLandForm { get; set; }
        public virtual RfParameterDetail BusinessLandArea { get; set; }
        public virtual RfParameterDetail BusinessCapacity { get; set; }
    }
}
