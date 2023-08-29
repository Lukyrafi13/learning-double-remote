using System;
namespace NewLMS.Umkm.Data.Dto.RFLinkages
{
    public class RFLinkageResponseDto
    {
        public Guid Id { get; set; }
        public string LinkCode { get; set; }
        public string LinkDesc { get; set; }
        public string SIKPCode { get; set; }
        public bool? Active { get; set; }
    }
}
