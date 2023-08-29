using System;
namespace NewLMS.UMKM.Data.Dto.Tenors
{
    public class TenorPostRequestDto
    {
        public string SCO_CODE { get; set; }
        public string SCO_DESC { get; set; }
        public string CORE_DESC { get; set; }
        public bool ACTIVE { get; set; }
    }
}
