using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfCompanyTypes
{
    public class RfCompanyTypeResponse : BaseResponse
    {
        public string CompanyTypeId { get; set; }
        public string CompanyTypeDesc { get; set; }
        public RfParameterDetailSimpleResponse ParamCompanyGroup { get; set; }
    }
}
