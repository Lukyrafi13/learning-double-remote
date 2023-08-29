using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFKepemilikanTUs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFKepemilikanTUProfile : Profile
    {
        public RFKepemilikanTUProfile()
        {
            CreateMap<RFKepemilikanTUPostRequestDto, RFKepemilikanTU>();
            CreateMap<RFKepemilikanTUPutRequestDto, RFKepemilikanTU>();
            CreateMap<RFKepemilikanTUResponseDto, RFKepemilikanTU>().ReverseMap();
        }
    }
}