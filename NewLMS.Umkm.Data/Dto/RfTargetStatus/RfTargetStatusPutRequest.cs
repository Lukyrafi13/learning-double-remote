using System;

namespace NewLMS.UMKM.Data.Dto.RfTargetStatuses
{
    public class RfTargetStatusPutRequestDto
    {
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
    }
}
