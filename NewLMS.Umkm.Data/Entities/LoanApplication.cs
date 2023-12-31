using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.Umkm.Data.Enums;

namespace NewLMS.Umkm.Data.Entities
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

        [ForeignKey(nameof(RfStage))]
        public Guid StageId { get; set; }
        public EnumLoanApplicationStatus Status { get; set; }
        public string DataSource { get; set; }

        [ForeignKey(nameof(DebtorCompany))]
        public Guid? DebtorCompanyId { get; set; }

        [ForeignKey(nameof(Debtor))]
        public Guid? DebtorId { get; set; }

        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(RfOwnerCategory))]
        public int OwnerCategoryId { get; set; }

        [ForeignKey(nameof(DecisionMaker))]
        public string? DecisionMakerId { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid? OwnerId { get; set; }

        public bool? IsBusinessCycle { get; set; }

        [ForeignKey(nameof(RfBusinessCycle))]
        public int? BusinessCycleId { get; set; }
        public int? BusinessCycleMonth { get; set; }

        [ForeignKey(nameof(RfBranch))]
        public string BranchId { get; set; }

        [ForeignKey(nameof(RfBookingBranch))]
        public string BookingBranchId { get; set; }

        public bool DuplicationsVerified { get; set; }


        public virtual RfDecisionMaker DecisionMaker { get; set; }
        public virtual User Owner { get; set; }

        public virtual RfParameterDetail RfOwnerCategory { get; set; }
        public virtual RfParameterDetail RfBusinessCycle { get; set; }

        public virtual Debtor Debtor { get; set; }
        public virtual DebtorCompany DebtorCompany { get; set; }
        public virtual DebtorEmergency DebtorEmergency { get; set; }
        public virtual Prospect Prospect { get; set; }

        public virtual RfBranch RfBookingBranch { get; set; }
        public virtual RfBranch RfBranch { get; set; }
        public virtual RfProduct RfProduct { get; set; }
        public virtual RfSectorLBU3 RfSectorLBU3 { get; set; }
        public virtual RfStage RfStage { get; set; }

        public virtual ICollection<LoanApplicationStage> LoanApplicationStages { get; set; } = new List<LoanApplicationStage>();
        public virtual ICollection<LoanApplicationCollateral> LoanApplicationCollaterals { get; set; } = new List<LoanApplicationCollateral>();
        public virtual ICollection<LoanApplicationKeyPerson> LoanApplicationKeyPersons { get; set; } = new List<LoanApplicationKeyPerson>();
        public virtual ICollection<LoanApplicationFacility> LoanApplicationFacilities { get; set; } = new List<LoanApplicationFacility>();
        public virtual ICollection<LoanApplicationCreditHistory> LoanApplicationCreditHistories { get; set; }
        public virtual LoanApplicationCreditScoring LoanApplicationCreditScoring { get; set; }
        public virtual LoanApplicationRAC LoanApplicationRAC { get; set; }
        public virtual LoanApplicationFieldSurvey LoanApplicationFieldSurvey { get; set; }
        public virtual LoanApplicationVerificationBusiness LoanApplicationVerificationBusiness { get; set; }
        public virtual LoanApplicationVerificationCycle LoanApplicationVerificationCycle { get; set; }
        public virtual LoanApplicationVerificationNeed LoanApplicationVerificationNeed { get; set; }
        public virtual SLIKRequest? SLIKRequest { get; set; }
        public virtual LoanApplicationBusinessInformation LoanApplicationBusinessInformation { get; set; }

        [NotMapped]
        public virtual string MappingTab { get; set; }
    }
}