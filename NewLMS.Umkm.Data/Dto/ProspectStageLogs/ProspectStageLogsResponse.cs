using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplicationStageLogss
{
    public class LoanApplicationStageLogsResponseDto
    {
        public Guid LoanApplicationStageLogId { get; set; }

        public Guid LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public Guid? RFRejectId { get; set; }

        public int StageId { get; set; }
        public RfStage RFStages { get; set; }
        public RFReject Alasan { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ExecutedDate { get; set; }

        public string ExecutedBy { get; set; }
        public string StatusSLIK { get; set; }

    }
}
