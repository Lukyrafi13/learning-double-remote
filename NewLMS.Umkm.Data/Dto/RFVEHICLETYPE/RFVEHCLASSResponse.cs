using System;
namespace NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs
{
    public class RFVEHICLETYPEResponseDto
    {
        public Guid Id { get; set; }
        public int VEH_CODE { get; set; }
        public string VEH_DESC { get; set; }
        public int CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
