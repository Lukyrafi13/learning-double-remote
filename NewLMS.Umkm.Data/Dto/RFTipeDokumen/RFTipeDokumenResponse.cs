using System;
namespace NewLMS.Umkm.Data.Dto.RFTipeDokumens
{
    public class RFTipeDokumenResponseDto
    {
        public Guid Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeDesc { get; set; }
        public bool? Active { get; set; }
    }
}
