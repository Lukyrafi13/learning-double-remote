using System;

namespace NewLMS.UMKM.Data.Dto.RFOwnerOTSs
{
    public class RFOwnerOTSResponseDto
    {
        public Guid Id { get; set; }
        public string OWN_CODE { get; set; }
        public string OWN_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
