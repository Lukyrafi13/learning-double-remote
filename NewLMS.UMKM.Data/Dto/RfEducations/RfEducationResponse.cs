using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfEducation
{
    public class RfEducationResponse : BaseResponse
    {
        public string EducationCode { get; set; }
        public string EducationDesc { get; set; }
        public string EducationCodeSIKP { get; set; }
        public string EducationDescSIKP { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfEducationSimpleResponse
    {
        public string EducationCode { get; set; }
        public string EducationDesc { get; set; }
    }
}
