using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCompanyGroupProfile : Profile
    {
        public RfCompanyGroupProfile()
        {
            CreateMap<RfCompanyGroupPostRequestDto, RfCompanyGroup>();
            CreateMap<RfCompanyGroupPutRequestDto, RfCompanyGroup>();
            CreateMap<RfCompanyGroupResponseDto, RfCompanyGroup>().ReverseMap();
        }
    }
}