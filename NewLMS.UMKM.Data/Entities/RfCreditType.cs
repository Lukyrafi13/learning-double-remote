using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfCreditType : BaseEntity
    {
        [Key]
        [Required]
        public string CreditTypeCode { get; set; }
        public string CreditTypeDesc { get; set; }
        public bool? CreditAgreement { get; set; }
    }
}
