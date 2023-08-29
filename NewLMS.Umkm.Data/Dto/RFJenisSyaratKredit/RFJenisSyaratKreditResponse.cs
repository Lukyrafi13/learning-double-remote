using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisSyaratKredits
{
    public class RFJenisSyaratKreditResponseDto
    {
        public Guid Id { get; set; }
        public string SyaratCode { get; set; }
        public string SyaratDesc { get; set; }
        public bool? Active { get; set; }
    }
}
