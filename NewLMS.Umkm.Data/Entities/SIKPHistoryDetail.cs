using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class SIKPHistoryDetail : BaseEntity
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [ForeignKey(nameof(SIKPHistory))]
        public Guid? SIKPHistoryId { get; set; }

        public string BanckCode { get; set; }
        public int? RemainingDay { get; set; }
        public string? Schema { get; set; }
        public string? TotalAkad { get; set; }
        public int? MaxTotalAkad { get; set; }
        public double? AllowedAkad { get; set; }
        public double? RateAkad { get; set; }
        public string? LimitActiveDefault { get; set; }
        public string? LimitActive { get; set; }
        public double? TotalLimit { get; set; }
        public double? AllowedRemainingPlafond { get; set; }

        public virtual SIKPHistory SIKPHistory { get; set; }
    }
}
