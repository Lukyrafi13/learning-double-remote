using System;
namespace NewLMS.UMKM.Data.Dto.RfTargetStatuss
{
    public class RfTargetStatusResponseDto
    {
        public Guid Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
    }
}
