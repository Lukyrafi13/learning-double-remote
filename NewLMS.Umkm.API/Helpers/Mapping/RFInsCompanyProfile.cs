using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFInsCompanys;

namespace NewLMS.UMKM.API.Helpers.Mapping

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