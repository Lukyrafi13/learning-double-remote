using System;
namespace NewLMS.Umkm.Data.Dto.RFJenisAsuransis
{
    public class RFJenisAsuransiResponseDto
    {
        public Guid Id { get; set; }
        public string JenisCode { get; set; }
        public string JenisDesc { get; set; }
        public bool? Active { get; set; }
    }
}
