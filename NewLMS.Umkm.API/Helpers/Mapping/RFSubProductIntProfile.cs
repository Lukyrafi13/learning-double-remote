using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSubProductInts;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
