using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfSubProducts;
using NewLMS.Umkm.Data.Entities;
using System;

namespace NewLMS.Umkm.Data.Dto.RfMappings
{
    public class RfMappingSubProductResponse
    {
        public Guid Id { get; set; }
        public int? ApplicationTypeId { get; set; }
        public int? CreditPurposeId { get; set; }
        public double? MinPlafond { get; set; }
        public double? MaxPlafond { get; set; }
        public string SubProductId { get; set; }

        public virtual RfSubProductSimpleResponse RfSubProduct { get; set; }
        public virtual RfParameterDetailSimpleResponse CreditPurpose { get; set; }
        public virtual RfParameterDetailSimpleResponse ApplicationType { get; set; }
    }
}
