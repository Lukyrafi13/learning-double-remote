using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCompanyTypeProfile : Profile
    {
        public RfCompanyTypeProfile()
        {
            CreateMap<RfCompanyTypePostRequestDto, RfCompanyType>();
            CreateMap<RfCompanyTypePutRequestDto, RfCompanyType>();
            CreateMap<RfCompanyTypeResponseDto, RfCompanyType>().ReverseMap();
        }
    }
}