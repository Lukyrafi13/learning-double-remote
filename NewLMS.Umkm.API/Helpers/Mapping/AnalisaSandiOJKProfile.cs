using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class AnalisaSandiOJKProfile : Profile
    {
        public AnalisaSandiOJKProfile()
        {
            CreateMap<AnalisaSandiOJKPostRequestDto, AnalisaSandiOJK>();
            CreateMap<AnalisaSandiOJKPutRequestDto, AnalisaSandiOJK>();
            CreateMap<AnalisaSandiOJKResponseDto, AnalisaSandiOJK>().ReverseMap();
        }
    }
}