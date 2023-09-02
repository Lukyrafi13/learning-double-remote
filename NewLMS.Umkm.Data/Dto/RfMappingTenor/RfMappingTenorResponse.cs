using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.Data.Dto.RfTenor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfMappingTenor
{
    public class RfMappingTenorResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public RfTenorSimpleResponse RfTenor { get; set; }
        public string SiklusCode { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
    }

    public class RfMappingTenorSimpleResponse
    {
        public Guid Id { get; set; }
        public RfTenorSimpleResponse RfTenor { get; set; }
        public string SiklusCode { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
    }
}
