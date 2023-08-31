using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.CompanyEntities;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class CompanyEntityProfile : Profile
    {
        public CompanyEntityProfile()
        {
            // CreateMap<CompanyEntity, CompanyEntityResponseDto>().ReverseMap();
            CreateMap<CompanyEntityPostRequestDto, CompanyEntity>();
            // CreateMap<CompanyEntityPutRequestDto, CompanyEntity>();
        }
    }
}