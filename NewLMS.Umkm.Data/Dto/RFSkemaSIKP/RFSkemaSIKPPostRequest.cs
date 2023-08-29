using System;

namespace NewLMS.UMKM.Data.Dto.RFSkemaSIKPs
{
    public class RFSkemaSIKPPostRequestDto
    {
        public Guid Id { get; set; }
        public string SkemaCode { get; set; }
        public string SkemaDesc { get; set; }
        public string SkemaParentCode { get; set; }
        public string SkemaParentDesc { get; set; }
        public bool? Active { get; set; }
    }
}
