using System;
namespace NewLMS.UMKM.Data.Dto.RFApprTanahLokasis
{
    public class RFApprTanahLokasiResponseDto
    {
        public Guid Id { get; set; }
        public string APPR_CODE { get; set; }
        public string APPR_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
