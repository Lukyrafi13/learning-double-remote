using NewLMS.UMKM.Data.Dto.RfProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfJob
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
