using System;

namespace NewLMS.UMKM.Data.Dto.SIKPHistoryDetails
{
    public class SIKPHistoryDetailPutRequestDto : SIKPHistoryDetailPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
