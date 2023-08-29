using System;
namespace NewLMS.UMKM.Data.Dto.ApprovalHistorys
{
    public class ApprovalHistoryResponseDto
    {
        public Approval Approval { get; set; }
        public Guid Id { get; set; }
        public Guid? ApprovalId { get; set; }
        public string ApprovalHistoryBy { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public string ApprovalHistorySeq { get; set; }
    }
}
