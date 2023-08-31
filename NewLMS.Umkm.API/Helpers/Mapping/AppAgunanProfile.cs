using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AppAgunans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class AppAgunanProfile : Profile
    {
        public AppAgunanProfile()
        {
            CreateMap<AppAgunanPostRequestDto, LoanApplicationCollateral>();
            CreateMap<AppAgunanPutRequestDto, LoanApplicationCollateral>();
            CreateMap<LoanApplicationCollateral, AppAgunanResponseDto>()
                .ForMember(d => d.RfZipCodeCollateral, s => s.MapFrom(d => d.RfZipCodeCollateral))
                .ForMember(d => d.RfZipCode, s => s.MapFrom(d => d.RfZipCode))
                .ForMember(d => d.RfZipCodeCouple, s => s.MapFrom(d => d.RfZipCodeCouple))
                .ForMember(d => d.RfAppType, s => s.MapFrom(d => d.RfAppType))
                .ForMember(d => d.RFMappingAgunan2, s => s.MapFrom(d => d.RFMappingAgunan2))
                .ForMember(d => d.ParamVehTypeCollateral, s => s.MapFrom(d => d.ParamVehTypeCollateral))
                .ForMember(d => d.RFDocument, s => s.MapFrom(d => d.RFDocument))
                .ForMember(d => d.RFVEHMAKER, s => s.MapFrom(d => d.RFVEHMAKER))
                .ForMember(d => d.RFVEHCLASS, s => s.MapFrom(d => d.RFVEHCLASS))
                .ForMember(d => d.RFVehModel, s => s.MapFrom(d => d.RFVehModel))
                .ForMember(d => d.ParamRealationCol, s => s.MapFrom(d => d.ParamRealationCol))
                .ForMember(d => d.MaritalId, s => s.MapFrom(d => d.MaritalId))
                .ForMember(d => d.ParamDeedType, s => s.MapFrom(d => d.ParamDeedType))
                ;
        }
    }
}