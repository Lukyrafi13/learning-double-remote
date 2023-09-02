using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfLoanPurpose : BaseEntity
    {
        [Key]
        [Required]
        public string LoanPurposeCode { get; set; }
        public string LoanPurposeDesc { get; set; }
        public int? MaxProd { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
