using NewLMS.UMKM.Data.Dto.RfProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfTenor
{
    public class RfTenorResponse : BaseResponse
    {
        public string TenorCode { get; set; }
        public string TenorDesc { get; set; }
        public int? Tenor { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfTenorSimpleResponse
    {
        public string TenorCode { get; set; }
        public string TenorDesc { get; set; }
        public int? Tenor { get; set; }
    }
}
