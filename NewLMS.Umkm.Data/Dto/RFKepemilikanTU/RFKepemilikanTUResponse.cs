using System;
namespace NewLMS.Umkm.Data.Dto.RFKepemilikanTUs
{
    public class RFKepemilikanTUResponseDto
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set; }
        public string ANL_DESC { get; set; }
        public string LOKASITEMPATUSAHA { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
