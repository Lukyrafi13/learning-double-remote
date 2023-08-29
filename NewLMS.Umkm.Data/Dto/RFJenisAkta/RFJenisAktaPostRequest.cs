using System;
namespace NewLMS.Umkm.Data.Dto.RFJenisAktas
{
    public class RFJenisAktaPostRequestDto
    {
        public string AktaCode { get; set; }
        public string AktaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
    }
}
