using System;

namespace NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas
{
    public class RFKepemilikanUsahaPostRequestDto
    {
        public Guid Id { get; set; }
        public string KepemilikanUsahaId { get; set; }
        public string KepemilikanUsahaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
