using System;
namespace NewLMS.UMKM.Data.Dto.RFTipeDokumens
{
    public class RFTipeDokumenPostRequestDto
    {
        public string TypeCode { get; set; }
        public string TypeDesc { get; set; }
        public bool? Active { get; set; }
    }
}
