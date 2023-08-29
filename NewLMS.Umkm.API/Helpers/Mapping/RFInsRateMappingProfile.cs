using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;

namespace NewLMS.Umkm.API.Helpers.Mapping

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