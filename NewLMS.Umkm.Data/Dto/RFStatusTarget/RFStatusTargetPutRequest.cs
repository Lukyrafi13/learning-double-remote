using System;

namespace NewLMS.Umkm.Data.Dto.RFStatusTargets
{
    public class RFStatusTargetPutRequestDto
    {
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
    }
}
