using NewLMS.UMKM.Data.Dto.RfVehModel;
using NewLMS.UMKM.Data.Dto.RfVehType;
using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfVehClass
{
    public class RfVehClassResponse : BaseResponse
    {
        public string VehClassCode { get; set; }
        public string VehClassDesc { get; set; }
        public RfVehTypeSimpleResponse RfVehType { get; set; }
        public RfVehModelSimplelResponse RfVehModel { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfVehClassSimpleResponse
    {
        public string VehClassCode { get; set; }
        public string VehClassDesc { get; set; }
    }
}
