using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SurveySuppliers;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SurveySupplierProfile : Profile
    {
        public SurveySupplierProfile()
        {
            CreateMap<SurveySupplierPostRequestDto, SurveySupplier>();
            CreateMap<SurveySupplierPutRequestDto, SurveySupplier>();
            CreateMap<SurveySupplierResponseDto, SurveySupplier>().ReverseMap();
        }
    }
}