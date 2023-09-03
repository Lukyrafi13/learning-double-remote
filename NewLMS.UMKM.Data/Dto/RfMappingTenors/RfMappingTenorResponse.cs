using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfTenor;
using System;

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
