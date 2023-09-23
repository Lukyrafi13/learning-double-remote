using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfSubProduct : BaseEntity
    {
        [Key]
        [Required]
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        
        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }
        public bool? MandNPWP { get; set; }
        
        [ForeignKey(nameof(RfLoanPurpose))]
        public string LoanPurposeCode { get; set; }
        public string SIKPSkema { get; set; }
        public string SIKPParentSkema { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }

        public virtual RfProduct RfProduct { get; set; }
        public virtual RfLoanPurpose RfLoanPurpose { get; set; }
    }
}
