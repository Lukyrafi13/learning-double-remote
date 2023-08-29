using System;
namespace NewLMS.UMKM.Data.Dto.RFSiklusUsahas
{
    public class RFSiklusUsahaResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string SiklusCode { get; set; }
        public string SiklusDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
