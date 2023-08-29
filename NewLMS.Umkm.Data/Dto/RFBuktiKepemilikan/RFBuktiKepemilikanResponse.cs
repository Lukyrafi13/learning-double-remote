using System;
namespace NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans
{
    public class RFBuktiKepemilikanResponseDto
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set;}
        public string ANL_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool ACTIVE { get; set;}
    }
}
