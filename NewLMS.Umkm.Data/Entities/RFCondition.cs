using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFCondition : BaseEntity
    {
        public Guid Id { get; set; }
        public string ConditionCode { get; set; }
        public string ConditionDesc { get; set; }
        public string ConditionCategory { get; set; }
        public bool? Active { get; set; }

    }
}
