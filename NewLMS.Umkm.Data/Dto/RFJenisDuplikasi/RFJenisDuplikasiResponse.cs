using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisDuplikasis
{
    public class RFJenisDuplikasiResponseDto
    {
        public Guid Id { get; set; }
        public string JenisCode { get; set; }
        public string JenisDesc { get; set; }
        public bool? Active { get; set; }
    }
}
