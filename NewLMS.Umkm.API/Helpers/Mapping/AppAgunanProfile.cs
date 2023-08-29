using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AppAgunans;

namespace NewLMS.UMKM.API.Helpers.Mapping

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