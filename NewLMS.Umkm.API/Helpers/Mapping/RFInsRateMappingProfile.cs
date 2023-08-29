using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFInsRateMappings;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFInsRateMappingProfile : Profile
    {
        public RFInsRateMappingProfile()
        {
            CreateMap<RFInsRateMappingPostRequestDto, RFInsRateMapping>();
            CreateMap<RFInsRateMappingPutRequestDto, RFInsRateMapping>();
            CreateMap<RFInsRateMappingResponseDto, RFInsRateMapping>().ReverseMap();
        }
    }
}