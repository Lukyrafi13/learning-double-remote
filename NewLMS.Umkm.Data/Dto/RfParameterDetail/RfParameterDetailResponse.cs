using NewLMS.UMKM.Data.Dto.RfParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfParameterDetail
{
    public class RfParameterDetailResponse : BaseResponse
    {
        public int ParameterDetailId { get; set; }
        public int ParameterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public RfParameterResponse RfParameter { get; set; }
    }

    public class RfParameterDetailSimpleResponse
    {
        public int ParameterDetailId { get; set; }
        public string Description { get; set; }
    }
}
