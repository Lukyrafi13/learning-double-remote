using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisAsuransis
{
    public class RFJenisAsuransiPostRequestDto
    {
        public string JenisCode { get; set; }
        public string JenisDesc { get; set; }
        public bool? Active { get; set; }
    }
}
