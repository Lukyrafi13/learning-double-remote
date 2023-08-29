using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFKepemilikanUsahaProfile : Profile
    {
        public RFKepemilikanUsahaProfile()
        {
            CreateMap<RFKepemilikanUsahaPostRequestDto, RFKepemilikanUsaha>();
            CreateMap<RFKepemilikanUsahaPutRequestDto, RFKepemilikanUsaha>();
            CreateMap<RFKepemilikanUsahaResponseDto, RFKepemilikanUsaha>().ReverseMap();
        }
    }
}