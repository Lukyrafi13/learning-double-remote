using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.BiayaTetaps;

namespace NewLMS.UMKM.API.Helpers.Mapping

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