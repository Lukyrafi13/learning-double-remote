using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisLinkAges
{
    public class RFJenisLinkAgeResponseDto
    {
        public Guid Id { get; set; }
        public string JenisLinkAgeCode { get; set; }
        public string JenisLinkAgeDesc { get; set; }
        public bool? Active { get; set; }
    }
}
