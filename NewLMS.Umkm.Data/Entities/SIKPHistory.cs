using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.Umkm.Data.Entities
{
    public class SIKPHistory : BaseEntity
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }
        public string NoIdentity { get; set; }
        public string BankCode { get; set; }
        public double? PlanPlafond { get; set; }
        public double? RateAkad { get; set; }
        public double? LimitActive { get; set; }
        public double? AllowedAkad { get; set; }
        public double? RemainingBookDays { get; set; }

        public virtual ICollection<SIKPHistoryDetail> SIKPHistoryDetails { get; set; }
    }
}
