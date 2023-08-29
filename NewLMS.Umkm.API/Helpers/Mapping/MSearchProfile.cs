using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.MSearchs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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