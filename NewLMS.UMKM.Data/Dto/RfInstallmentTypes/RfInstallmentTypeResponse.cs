using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfInstallmentTypes
{
    public class RfInstallmentTypeResponse : BaseResponse
    {
        public string InstallmentTypeCode { get; set; }
        public string InstallmentTypeDesc { get; set; }
    }

    public class RfInstallmentTypeSimpleResponse
    {
        public string InstallmentTypeCode { get; set; }
        public string InstallmentTypeDesc { get; set; }
    }
}
