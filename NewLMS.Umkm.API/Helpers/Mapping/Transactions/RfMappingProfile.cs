﻿using AutoMapper;
using NewLMS.Umkm.Data.Dto.RfMappingDocumentPrescreenings;
using NewLMS.Umkm.Data.Dto.RfMappingPlafondPlacementCountries;
using NewLMS.Umkm.Data.Dto.RfMappings;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class RfMappingProfile : Profile
    {
        public RfMappingProfile()
        {
            CreateMap<RfMappingSubProduct, RfMappingSubProductResponse>();
            CreateMap<RfMappingDocumentPrescreening, RfMappingDocumentPrescreeningResponse>();
            CreateMap<RfMappingPlafondPlacementCountry, RfMappingPlafondPlacementCountriesResponse>();
        }
    }
}
