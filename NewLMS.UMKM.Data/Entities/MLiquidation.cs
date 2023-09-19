using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class MLiquidation : BaseEntity
    {
        [MaxLength(5)]
        public string TypeId { get; set; }
        [MaxLength(100)]
        public string TypeDesc { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<MLiquidationCondition> MLiquidationConditions { get; set; }
        public virtual ICollection<MLiquidationItem> MLiquidationItems { get; set; }
        // public virtual ICollection<MLiquidationOption> MLiquidationOptions { get; set; }
    }
}
