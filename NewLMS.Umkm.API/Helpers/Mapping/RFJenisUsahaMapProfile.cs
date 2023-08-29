using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCompanyTypeMapProfile : Profile
    {
        public RfCompanyTypeMapProfile()
        {
            CreateMap<RfCompanyTypeMapPostRequestDto, RfCompanyTypeMap>();
            CreateMap<RfCompanyTypeMapPutRequestDto, RfCompanyTypeMap>();
            CreateMap<RfCompanyTypeMapResponseDto, RfCompanyTypeMap>().ReverseMap();
            CreateMap<RfCompanyTypeByKelompokResponse, RfCompanyTypeMap>().ReverseMap();
        }
    }
}