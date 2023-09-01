using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AppAgunans;

namespace NewLMS.UMKM.API.Helpers.Mapping{
    public class AppAgunanProfile : Profile
    {
        public AppAgunanProfile()
        {
            CreateMap<AppAgunanPostRequestDto, LoanApplicationCollateral>();
            CreateMap<AppAgunanPutRequestDto, LoanApplicationCollateral>();
            CreateMap<LoanApplicationCollateral, AppAgunanResponseDto>();
        }
    }
}