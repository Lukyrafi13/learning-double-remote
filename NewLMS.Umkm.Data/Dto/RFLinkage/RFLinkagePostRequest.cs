using System;
namespace NewLMS.Umkm.Data.Dto.RFLinkages
{
    public class RFLinkagePostRequestDto
    {
        public string LinkCode { get; set; }
        public string LinkDesc { get; set; }
        public string SIKPCode { get; set; }
        public bool? Active { get; set; }
    }
}
