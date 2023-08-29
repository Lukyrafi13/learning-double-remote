using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTenorMappings;

namespace NewLMS.UMKM.API.Helpers.Mapping

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