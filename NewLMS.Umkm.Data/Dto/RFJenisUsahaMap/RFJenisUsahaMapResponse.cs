using System;
namespace NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps
{
    public class RFJenisUsahaMapResponseDto
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set;}
        public string ANL_DESC { get; set;}
        public bool ANL_ACTIVE { get; set;}
        public string KELOMPOK_CODE { get; set;}
        public string PRODUCTID { get; set;}
    }
}
