using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class BiayaTetapProfile : Profile
    {
        public BiayaTetapProfile()
        {
            CreateMap<BiayaTetap, BiayaTetapResponseDto>().ReverseMap();
            CreateMap<BiayaTetapPostRequestDto, BiayaTetap>();
            CreateMap<BiayaTetapPutRequestDto, BiayaTetap>();
        }
    }
}