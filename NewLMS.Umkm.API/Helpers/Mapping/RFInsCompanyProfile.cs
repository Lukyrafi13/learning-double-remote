using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFInsCompanys;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFInsCompanyProfile : Profile
    {
        public RFInsCompanyProfile()
        {
            CreateMap<RFInsCompanyPostRequestDto, RFInsCompany>();
            CreateMap<RFInsCompanyPutRequestDto, RFInsCompany>();
            CreateMap<RFInsCompanyResponseDto, RFInsCompany>().ReverseMap();
        }
    }
}