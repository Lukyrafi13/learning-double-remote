using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Dto.RfDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfDocumentCollateral : BaseEntity
    {
        [Key]
        [Required]
        public Guid DocumentCollateralCode { get; set; }
        [ForeignKey(nameof(RfDocument))]
        public string DocumentCode { get; set; }
        [ForeignKey(nameof(RfCollateralBC))]
        public string CollateralCode { get; set; }
        public bool Active { get; set; }

        public virtual RfDocument RfDocument { get; set; }
        public virtual RfCollateralBC RfCollateralBC { get; set; }
    }
}
