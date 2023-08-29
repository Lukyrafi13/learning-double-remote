using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJOBs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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