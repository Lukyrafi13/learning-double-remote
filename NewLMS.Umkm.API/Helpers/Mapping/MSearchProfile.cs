using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.MSearchs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class MSearchProfile : Profile
    {
        public MSearchProfile()
        {
            CreateMap<MSearchPostRequestDto, MSearch>();
            CreateMap<MSearchPutRequestDto, MSearch>();
            CreateMap<MSearchResponseDto, MSearch>().ReverseMap();
        }
    }
}