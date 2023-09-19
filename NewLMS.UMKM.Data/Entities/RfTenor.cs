using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfTenor : BaseEntity
    {
        [Key]
        [Required]
        public string TenorCode { get; set; }
        public string TenorDesc { get; set; }
        public int? Tenor { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
        
        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }

        public virtual RfProduct RfProduct { get; set; }
    }
}
