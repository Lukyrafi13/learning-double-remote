using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfParameters
{
    public class RfParameterResponse : BaseResponse
    {
		public int ParameterId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<RfParameterDetailResponse> RfParameterDetails { get; set; }
	}
}
