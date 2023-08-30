using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyStatuses;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RfCompanyStatusProfile : Profile
    {
        public RfCompanyStatusProfile()
        {
            CreateMap<RfCompanyStatus, RfCompanyStatusResponse>();
            CreateMap<RfCompanyStatusFindRequest, RfCompanyStatus>();
        }
    }
}
