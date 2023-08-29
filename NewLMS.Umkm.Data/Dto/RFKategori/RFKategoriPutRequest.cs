using System;

namespace NewLMS.Umkm.Data.Dto.RFKategoris
{
    public class RFKategoriPutRequestDto
    {
        public string KategoriCode { get; set; }
        public string KategoriDesc { get; set; }
        public bool Active { get; set; }
    }
}
