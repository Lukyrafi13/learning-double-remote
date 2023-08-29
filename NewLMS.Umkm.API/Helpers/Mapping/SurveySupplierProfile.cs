using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;

namespace NewLMS.Umkm.API.Helpers.Mapping

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