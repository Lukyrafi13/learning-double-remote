using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class MLiquidationItem : BaseEntity
    {
        public string TypeId { get; set; }
        [MaxLength(5)]
        public string ItemId { get; set; }
        [MaxLength(100)]
        public string ItemDesc { get; set; }
        public double? ItemWeight { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual MLiquidation MLiquidation { get; set; }
        public virtual ICollection<MLiquidationOption> MLiquidationOptions { get; set; }
        public virtual ICollection<ApprLiquidation> ApprLiquidations { get; set; }
    }
}
