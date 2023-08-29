using System;
namespace NewLMS.Umkm.Data.Dto.RFDecisionSKs
{
    public class RFDecisionSKResponseDto
    {
        public Guid Id { get; set; }
        public string DEC_CODE { get; set;}
        public string DEC_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool ACTIVE { get; set;}
    }
}
