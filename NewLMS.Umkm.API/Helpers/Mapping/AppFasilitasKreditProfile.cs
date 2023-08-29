using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AppFasilitasKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping

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