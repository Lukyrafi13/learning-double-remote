using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisAktas
{
    public class RFJenisAktaPostRequestDto
    {
        public string AktaCode { get; set; }
        public string AktaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
    }
}
