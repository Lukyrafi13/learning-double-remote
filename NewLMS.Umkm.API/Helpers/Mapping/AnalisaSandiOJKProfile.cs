using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AnalisaSandiOJKs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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