using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfMappingSubProduct : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ApplicationType))]
        public int? ApplicationTypeId { get; set; }

        [ForeignKey(nameof(CreditPurpose))]
        public int? CreditPurposeId { get; set; }

        public double? MinPlafond { get; set; }
        public double? MaxPlafond { get; set; }
        
        [ForeignKey(nameof(RfSubProduct))]
        public string SubProductId { get; set; }

        public virtual RfProduct RfProduct { get; set; }
        public virtual RfSubProduct RfSubProduct { get; set; }
        public virtual RfParameterDetail CreditPurpose { get; set; }
        public virtual RfParameterDetail ApplicationType { get; set; }

    }
}
