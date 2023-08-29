using System;
namespace NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks
{
    public class RFSiklusUsahaPokokResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string SiklusCode { get; set; }
        public string SiklusDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
