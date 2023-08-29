using System;
namespace NewLMS.Umkm.Data.Dto.RFPolaPengembalians
{
    public class RFPolaPengembalianResponseDto
    {
        public Guid Id { get; set; }
        public string PolaCode { get; set; }
        public string PolaDesc { get; set; }
        public bool? Active { get; set; }
    }
}
