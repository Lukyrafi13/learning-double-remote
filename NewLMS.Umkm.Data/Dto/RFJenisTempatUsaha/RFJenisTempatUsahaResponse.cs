using System;
namespace NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas
{
    public class RFJenisTempatUsahaResponseDto
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set; }
        public string ANL_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool? ACTIVE { get; set; }
        public string PRODUCTID { get; set; }
    }
}
