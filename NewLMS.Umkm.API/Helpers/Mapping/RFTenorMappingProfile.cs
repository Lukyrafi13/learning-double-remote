using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTenorMappings;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFTenorMappingProfile : Profile
    {
        public RFTenorMappingProfile()
        {
            CreateMap<RFTenorMappingPostRequestDto, RFTenorMapping>();
            CreateMap<RFTenorMappingPutRequestDto, RFTenorMapping>();
            CreateMap<RFTenorMappingResponseDto, RFTenorMapping>().ReverseMap();
        }
    }
}