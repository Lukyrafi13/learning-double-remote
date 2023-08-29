using System;

namespace NewLMS.UMKM.Data.Dto.RfCategorys
{
    public class RfCategoryPutRequestDto
    {
        public string KategoriCode { get; set; }
        public string KategoriDesc { get; set; }
        public bool Active { get; set; }
    }
}
