using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NewLMS.UMKM.Data.Dto.RfStages;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationAppraisal : BaseEntity
    {
        [Key]
        [Required]
        public Guid AppraisalId { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        [ForeignKey(nameof(LoanApplicationCollateral))]
        public Guid LoanApplicationCollateralId { get; set; }

        public Boolean isInternal { get; set; }
        public Boolean isExternal { get; set; }
        [MaxLength(50)]
        public string Estimator { get; set; }
        [MaxLength(50)]
        public string Kjpp { get; set; }
        [MaxLength(50)]
        public string PropertyCategory { get; set; }
        [MaxLength(25)]
        public string AppraisalStatus { get; set; }
        
        [ForeignKey(nameof(RfStage))]
        public Guid StageId { get; set; }

        public virtual LoanApplicationCollateral LoanApplicationCollateral { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfStage RfStage { get; set; }

        [NotMapped]
        public virtual string MappingTab { get; set; }
        /*        public virtual ICollection<ApprReceivableVerification> ApprReceivableVerifications { get; set; }
                public virtual ICollection<ApprWorkPaperLandBuildingSummaries> ApprWorkPaperLandBuildingSummaries { get; set; }
                public virtual ICollection<ApprWorkPaperMachineMarketSummaries> ApprWorkPaperMachineMarketSummaries { get; set; }
                public virtual ICollection<ApprWorkPaperShopApartmentSummaries> ApprWorkPaperShopApartmentSummaries { get; set; }
                public virtual ICollection<ApprWorkPaperVehicleSummaries> ApprWorkPaperVehicleSummaries { get; set; }*/
    }
}
