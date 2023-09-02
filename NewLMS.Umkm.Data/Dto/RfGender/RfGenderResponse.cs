using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfGender
{
    public class RfGenderResponse : BaseResponse
    {
        public string GenderCode { get; set; }
        public string GenderDesc { get; set; }
        public string GenderCodeSIKP { get; set; }
        public string GenderDescSIKP { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfGenderSimpleResponse
    {
        public string GenderCode { get; set; }
        public string GenderDesc { get; set; }
    }


}
