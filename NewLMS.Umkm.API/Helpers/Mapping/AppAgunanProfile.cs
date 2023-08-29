using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AppAgunans;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AppAgunanProfile : Profile
    {
        public AppAgunanProfile()
        {
            CreateMap<AppAgunanPostRequestDto, AppAgunan>();
            CreateMap<AppAgunanPutRequestDto, AppAgunan>();
            CreateMap<AppAgunanResponseDto, AppAgunan>().ReverseMap();
        }
    }
}