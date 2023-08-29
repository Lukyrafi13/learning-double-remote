using System;

namespace NewLMS.Umkm.Data.Dto.ApprovalHistorys
{
    public class ApprovalHistoryPutRequestDto : ApprovalHistoryPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
