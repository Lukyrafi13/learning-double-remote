using System;
namespace NewLMS.UMKM.Data.Dto.SCJabatans
{
    public class SCJabatanResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string JAB_CODE { get; set; }
        public string JAB_DESC { get; set; }
        public string SK_CODE { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
        public string SK_LIMIT_CODE { get; set; }
    }
}
