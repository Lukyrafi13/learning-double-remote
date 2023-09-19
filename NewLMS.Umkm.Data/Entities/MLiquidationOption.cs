using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class MLiquidationOption : BaseEntity
    {
        public string TypeId { get; set; }
        public string ItemId { get; set; }
        [MaxLength(10)]
        public string OptionId { get; set; }
        [MaxLength(100)]
        public string OptionDesc { get; set; }
        public double? OptionWeight { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual MLiquidationItem MLiquidationItem { get; set; }
        public virtual ICollection<ApprLiquidation> ApprLiquidations { get; set; }
    }
}
