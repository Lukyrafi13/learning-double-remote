using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplicationStageLogss
{
    public class LoanApplicationStageLogsResponseDto
    {
        
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public DateTime? ExecutedDate { get; set; }
        public Guid? ExecutedBy { get; set; }
        public Guid? DispatchedTo { get; set; }

        public Guid? StageId { get; set; }

        public Guid? TargetStage { get; set; }
        public string? Aging { get; set; }
        public bool? BackStaged { get; set; }
        public Guid? RFRejectId { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public RfStage RfStage { get; set; }
        public RfStage RfStageTarget { get; set; }

    }
}
