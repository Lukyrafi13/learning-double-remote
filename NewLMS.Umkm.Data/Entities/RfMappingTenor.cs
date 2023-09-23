using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfMappingTenor : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [ForeignKey(nameof(RfTenor))]
        public string TenorCode { get; set; }
        
        public string SiklusCode { get; set; }
        
        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(RfLoanPurpose))]
        public string LoanPurposeCode { get; set; }

        [ForeignKey(nameof(ParamApplicationType))]
        public int? ParamApplicationTypeId { get; set; }

        [ForeignKey(nameof(RfSubProduct))]
        public string SubProductId { get; set; }

        public virtual RfTenor RfTenor { get; set; }
        public virtual RfProduct RfProduct { get; set; }
        public virtual RfLoanPurpose RfLoanPurpose { get; set; }
        public virtual RfParameterDetail ParamApplicationType { get; set; }
        public virtual RfSubProduct RfSubProduct { get; set; }
    }
}
