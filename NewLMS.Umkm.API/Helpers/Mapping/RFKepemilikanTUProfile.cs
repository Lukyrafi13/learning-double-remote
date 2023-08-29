using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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