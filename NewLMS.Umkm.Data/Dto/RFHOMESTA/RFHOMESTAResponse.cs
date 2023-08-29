using System;
namespace NewLMS.Umkm.Data.Dto.RFHOMESTAs
{
    public class RFHOMESTAResponseDto
    {
        public Guid Id { get; set; }
        public string HMSTA_CODE { get; set; }
        public string HMSTA_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
