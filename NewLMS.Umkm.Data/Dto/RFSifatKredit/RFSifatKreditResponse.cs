using System;
namespace NewLMS.Umkm.Data.Dto.RFSifatKredits
{
    public class RFSifatKreditResponseDto
    {
        public Guid Id { get; set; }
        public string SKCode { get; set; }
        public string SKDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
