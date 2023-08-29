using System;
namespace NewLMS.UMKM.Data.Dto.RFJOBs
{
    public class RFJOBResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string JOB_CODE { get; set;}
        public string JOB_DESC { get; set; }
        public string JOB_TYPE { get; set; }
        public string JOBSCR_TYPE { get; set; }
        public bool? SENSITIVE { get; set; }
        public int CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
        public bool? OTHER { get; set; }
        public string PRODUCTID { get; set; }
        public string JOB_CODESIKP { get; set; }
        public string JOB_DESCSIKP { get; set; }
    }
}
