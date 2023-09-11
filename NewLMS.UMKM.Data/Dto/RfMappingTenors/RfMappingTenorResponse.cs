using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.Data.Dto.RfTenor;
using NewLMS.UMKM.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Dto.RfMappingTenor
{
    public class RfMappingTenorResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public RfTenorSimpleResponse RfTenor { get; set; }
        public string SiklusCode { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public RfLoanPurposeSimpleResponse RfLoanPurpose { get; set; }
        public RfParameterDetailSimpleResponse ParamApplicationType { get; set; }
        public RfSubProductSimpleResponse RfSubProduct { get; set; }
    }

    public class RfMappingTenorSimpleResponse
    {
        public Guid Id { get; set; }
        public RfTenorSimpleResponse RfTenor { get; set; }
        public string SiklusCode { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
    }
}
