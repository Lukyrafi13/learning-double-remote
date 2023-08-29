using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJOBs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJOBProfile : Profile
    {
        public RFJOBProfile()
        {
            CreateMap<RFJOBPostRequestDto, RFJOB>();
            CreateMap<RFJOBPutRequestDto, RFJOB>();
            CreateMap<RFJOBResponseDto, RFJOB>().ReverseMap();
        }
    }
}