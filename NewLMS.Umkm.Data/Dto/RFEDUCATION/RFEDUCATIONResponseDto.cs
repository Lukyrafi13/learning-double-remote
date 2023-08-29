using System;
namespace NewLMS.UMKM.Data.Dto.RFEDUCATIONs
{
    public class RFEDUCATIONResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string ED_CODE { get; set; }
        public string ED_DESC { get; set; }
        public string ED_CODESIKP { get; set; }
        public string ED_DESCSIKP { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
