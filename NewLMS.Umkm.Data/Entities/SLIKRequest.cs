using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Enums;

namespace NewLMS.Umkm.Data
{
    public class SLIKRequest : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplication))]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Branch))]
        public string BranchCode { get; set; }
        [ForeignKey(nameof(RfStage))]
        public Guid? StageId { get; set; }
        public string Comment { get; set; }
        public EnumSLIKStatus Status { get; set; }
        public bool? ReadAndUnderstand { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool AdminVerified { get; set; }
        public double TotalCreditCard { get; set; }
        public double TotalLimitSlik { get; set; }
        public double TotalOtherUses { get; set; }
        public double TotalWorkingCapital { get; set; }
        public DateTime? InquiryDate { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfBranch Branch { get; set; }
        public virtual RfStage RfStage { get; set; }
        public virtual ICollection<SLIKRequestDebtor> SLIKRequestDebtors { get; set; }
    }
}