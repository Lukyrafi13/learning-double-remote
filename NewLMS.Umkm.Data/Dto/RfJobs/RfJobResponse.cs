using NewLMS.Umkm.Data.Dto.RfProducts;

namespace NewLMS.Umkm.Data.Dto.RfJob
{
    public class RfJobResponse : BaseResponse
    {
        public string JobCode { get; set; }
        public string JobDesc { get; set; }
        public string JobType { get; set; }
        public string JobSCRType { get; set; }
        public string JobCodeSIKP { get; set; }
        public string JobDescSIKP { get; set; }
        public bool? Sensitive { get; set; }
        public bool? Other { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfJobSimpleResponse
    {
        public string JobCode { get; set; }
        public string JobDesc { get; set; }
    }
}
