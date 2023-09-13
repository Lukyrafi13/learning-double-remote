using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfMappingCollateral : BaseEntity
    {
        [Key]
        [Required]
        public Guid MappingCollateralId { get; set; }
        
        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }
        
        [ForeignKey(nameof(RfCollateralBC))]
        public string CollateralCode { get; set; }
       
        public bool Active { get; set; }

        public virtual RfProduct RfProduct { get; set; }
        public virtual RfCollateralBC RfCollateralBC { get; set; }
    }
}
