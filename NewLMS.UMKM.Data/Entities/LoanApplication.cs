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
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string LoanApplicationId { get; set; }

        [Required]
        [ForeignKey(nameof(Prospect))]
        public Guid? ProspectId { get; set; }

        [ForeignKey(nameof(Stage))]
        public Guid StageId { get; set; }
        public EnumLoanApplicationStatus Status { get; set; }
        // etc
        public string DataSource { get; set; }

        [ForeignKey(nameof(DebtorCompany))]
        public Guid? DebtorCompanyId { get; set; }

        [ForeignKey(nameof(Debtor))]
        public Guid? DebtorId { get; set; }

        [ForeignKey(nameof(RfOwnerCategory))]
        public int OwnerCategoryId { get; set; }

        [ForeignKey(nameof(DecisionMaker))]
        public Guid? DecisionMakerId { get; set; }
        
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        // Other stage
        public virtual User Owner { get; set; }
        public virtual User DecisionMaker { get; set; }

        public virtual RfParameterDetail RfOwnerCategory { get; set; }
        
        public virtual Debtor Debtor { get; set; }
        public virtual DebtorCompany DebtorCompany { get; set; }
        public virtual Prospect Prospect { get; set; }

        public virtual RfBranch BookingOffice { get; set; }
        public virtual RfBranch RfBranch { get; set; }
        public virtual RfProduct RfProduct { get; set; }
        public virtual RfSectorLBU3 RfSectorLBU3 { get; set; }
        public virtual RfSubProduct RfSubProduct { get; set; }
        public virtual RfStage RfStage { get; set; }


        public virtual ICollection<LoanApplicationStageLog> LoanApplicationStageLogs { get; set; }
        public virtual LoanApplicationCreditScoring LoanApplicationCreditScoring { get; set; }


    }
}