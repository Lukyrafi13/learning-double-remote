using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
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

        public virtual RfTenor RfTenor { get; set; }
        public virtual RfProduct RfProduct { get; set; }
    }
}
