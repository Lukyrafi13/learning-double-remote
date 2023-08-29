using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisDuplikasis
{
    public class RFJenisDuplikasiPostRequestDto
    {
        public string JenisCode { get; set; }
        public string JenisDesc { get; set; }
        public bool? Active { get; set; }
    }
}
