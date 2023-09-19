using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfLoanPurpose;
using NewLMS.Umkm.Data.Dto.RfProducts;
using NewLMS.Umkm.Data.Dto.RfSubProducts;
using NewLMS.Umkm.Data.Dto.RfTenor;
using NewLMS.Umkm.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Dto.RfMappingTenor
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
