using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationVerificationNeedDetail : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        public string NeedsDetail { get; set; }
        public string Description { get; set; }
        public double? Total { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public double? TotalPrice { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
    }
}
