using System;
namespace NewLMS.UMKM.Data.Dto.RFMARITALs
{
    public class RFMARITALResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string MR_CODE { get; set; }        
        public string MR_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool? WITHSPOUSE { get; set; }
        public bool ACTIVE { get; set; }
        public string MR_CODESIKP { get; set; }
        public string MR_DESCSIKP { get; set; }
    }
}
