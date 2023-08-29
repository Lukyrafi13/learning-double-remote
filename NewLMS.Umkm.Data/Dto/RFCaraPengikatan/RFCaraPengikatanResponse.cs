using System;
namespace NewLMS.UMKM.Data.Dto.RFCaraPengikatans
{
    public class RFCaraPengikatanResponseDto
    {
        public Guid Id { get; set; }
        public string PK_CODE { get; set; }
        public string PK_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
