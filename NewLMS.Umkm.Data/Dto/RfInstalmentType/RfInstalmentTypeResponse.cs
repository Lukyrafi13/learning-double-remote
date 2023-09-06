using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfInstalmentType
{
    public class RfInstalmentTypeResponse : BaseResponse
    {
        public string InstalmentTypeId { get; set; }
        public string InstalmentTypeDesc { get; set; }
    }

    public class RfInstalmentTypeSimpleResponse
    {
        public string InstalmentTypeId { get; set; }
        public string InstalmentTypeDesc { get; set; }
    }
}
