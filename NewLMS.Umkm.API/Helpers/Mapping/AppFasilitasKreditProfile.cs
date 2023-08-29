using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AppFasilitasKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AppFasilitasKreditProfile : Profile
    {
        public AppFasilitasKreditProfile()
        {
            CreateMap<AppFasilitasKredit, AppFasilitasKreditResponseDto>().ReverseMap();
            CreateMap<AppFasilitasKreditPostRequestDto, AppFasilitasKredit>();
            CreateMap<AppFasilitasKreditPutRequestDto, AppFasilitasKredit>();
        }
    }
}