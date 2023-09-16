using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class MLiquidationCondition : BaseEntity
    {
        public string TypeId { get; set; }
        [MaxLength(5)]
        public string ConditionId { get; set; }
        [MaxLength(100)]
        public string Condition { get; set; }
        public double? Result { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual MLiquidation MLiquidation { get; set; }
    }
}
