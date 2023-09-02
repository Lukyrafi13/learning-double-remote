using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfOwnerCategory
{
    public class RfOwnerCategoryResponse : BaseResponse
    {
        public string OwnerCategoryCode { get; set; }
        public string OwnerCategoryDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfOwnerCategorySimpleResponse
    {
        public string OwnerCategoryCode { get; set; }
        public string OwnerCategoryDesc { get; set; }
    }
}
