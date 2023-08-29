using System;

namespace NewLMS.UMKM.Data.Dto.ApprovalHistorys
{
    public class ApprovalHistoryPutRequestDto : ApprovalHistoryPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
