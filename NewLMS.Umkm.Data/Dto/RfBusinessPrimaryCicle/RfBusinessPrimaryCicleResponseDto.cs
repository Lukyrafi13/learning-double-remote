using System;
namespace NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles
{
    public class RfBusinessPrimaryCicleResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string CycleCode { get; set; }
        public string CyclDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
