using System;
namespace NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits
{
    public class RFJenisSyaratKreditPostRequestDto
    {
        public string SyaratCode { get; set; }
        public string SyaratDesc { get; set; }
        public bool? Active { get; set; }
    }
}
