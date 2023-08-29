using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSubProductInts;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSubProductIntProfile : Profile
    {
        public RFSubProductIntProfile()
        {
            CreateMap<RFSubProductIntPostRequestDto, RFSubProductInt>();
            CreateMap<RFSubProductIntPutRequestDto, RFSubProductInt>();
            CreateMap<RFSubProductIntResponseDto, RFSubProductInt>().ReverseMap();
        }
    }
}
