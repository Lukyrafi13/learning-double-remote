using System;
namespace NewLMS.UMKM.Data.Dto.RFCSBPHeaders
{
    public class RFCSBPHeaderResponseDto
    {
        public Guid Id { get; set; }
        public string CSBPGroupID { get; set; }
        public string CSBPGroupName { get; set; }
        public string CSBPGroupDesc { get; set; }
    }
}
