using System;
namespace NewLMS.UMKM.Data.Dto.RFPolaPengembalians
{
    public class RFPolaPengembalianResponseDto
    {
        public Guid Id { get; set; }
        public string PolaCode { get; set; }
        public string PolaDesc { get; set; }
        public bool? Active { get; set; }
    }
}
