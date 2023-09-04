using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.Data
{
    public class LoanApplication : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]

        public string LoanApplicationId { get; set; }
        [ForeignKey(nameof(Prospect))]
        public Guid? ProspectId { get; set; }

        [ForeignKey(nameof(RfOwnerCategory))]
        public Guid? RfOwnerCategoryId { get; set; }

        // etc
        public string DataSource { get; set; }

        [MaxLength(16)]
        [ForeignKey(nameof(Debtor))]
        public string NoIdentity { get; set; }

        [ForeignKey(nameof(CompanyEntity))]
        public Guid? CompanyEntityGuid { get; set; }
        [ForeignKey(nameof(BookingOffice))]
        public string RfBranchId { get; set; }
        [ForeignKey(nameof(RfDecisionMakerId))]
        public int? RfDecisionMakerId { get; set; }
        [ForeignKey(nameof(User))]
        public Guid? OwnerId { get; set; }

        // Other stage
        public RfOwnerCategory RfOwnerCategory { get; set; }
        public Debtor Debtor { get; set; }
        public Prospect Prospect { get; set; }

        public RfBranch BookingOffice { get; set; }
        public RfParameterDetail DecisionMaker { get; set; }
        public User User { get; set; }
        public RfStage Stage { get; set; }

        // public ICollection<LoanApplicationStageLog> LoanApplicationStageLogs { get; set; }
        public LoanApplicationCreditScoring LoanApplicationCreditScoring { get; set; }


    }
}