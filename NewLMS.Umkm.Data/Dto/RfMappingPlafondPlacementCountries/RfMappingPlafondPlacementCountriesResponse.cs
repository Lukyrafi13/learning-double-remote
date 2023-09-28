using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfPlacementCountry;
using System;

namespace NewLMS.Umkm.Data.Dto.RfMappingPlafondPlacementCountries
{
    public class RfMappingPlafondPlacementCountriesResponse
    {
        public Guid Id { get; set; }
        public string PlacementCountryCode { get; set; }
        public int? ApplicationTypeCode { get; set; }
        public double? MaximumPlafond { get; set; }

        public virtual RfPlacementCountrySimpleResponse RfPlacementCountry { get; set; }
        public virtual RfParameterDetailSimpleResponse ApplicationType { get; set; }
    }
}
