using System;
namespace NewLMS.Umkm.Data.Dto.ProspectStageLogss
{
    public class ProspectStageLogsResponseDto
    {
        public Guid LoanApplicationStageLogId { get; set; }

        public Guid ProspectId { get; set; }
        public Prospect Prospect { get; set; }
        public Guid? RFRejectId { get; set; }

        public int StageId { get; set; }
        public RFStages RFStages { get; set; }
        public RFReject Alasan { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ExecutedDate { get; set; }

        public string ExecutedBy { get; set; }
        public string StatusSLIK { get; set; }

    }
}
