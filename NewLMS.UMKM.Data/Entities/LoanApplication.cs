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
        public int Status { get; set; }
        // etc
        public string DataSource { get; set; }

        [ForeignKey(nameof(DebtorCompany))]
        public string DebtorCompanyId { get; set; }

        [ForeignKey(nameof(RfParameterDetail))]
        public string OwnerCategoryId { get; set; }

        [ForeignKey(nameof(RfParameterDetail))]
        public int? DecisionMakerId { get; set; }
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }

        // Other stage
        public virtual Debtor Debtor { get; set; }
        public virtual Prospect Prospect { get; set; }
        public virtual RfBranch Branch { get; set; }
        public virtual RfProduct Product { get; set; }
        public virtual RfSectorLBU3 SectorLBU3 { get; set; }
        public virtual RfSubProduct SubProduct { get; set; }

        public virtual RfParameterDetail DecisionMaker { get; set; }
        public virtual RfParameterDetail OwnerCategory { get; set; }
        public virtual User User { get; set; }
        public virtual RfStage Stage { get; set; }

        // public virtual SLIKRequest SLIKRequest { get; set; }
        public virtual DebtorCompany DebtorCompany { get; set; }

        public virtual ICollection<LoanApplicationStageLog> LoanApplicationStageLogs { get; set; }
        public virtual LoanApplicationCreditScoring LoanApplicationCreditScoring { get; set; }


    }
}