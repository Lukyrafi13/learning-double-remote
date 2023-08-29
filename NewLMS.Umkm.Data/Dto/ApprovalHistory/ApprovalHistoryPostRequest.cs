using System;

namespace NewLMS.Umkm.Data.Dto.ApprovalHistorys
{
    public class ApprovalHistoryPostRequestDto
    {
        public Guid? ApprovalId { get; set; }
        public string ApprovalHistoryBy { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public int ApprovalHistorySeq { get; set; }

    }
}
