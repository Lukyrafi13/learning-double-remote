using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SlikRequests;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class SlikRequestProfile : Profile
    {
        public SlikRequestProfile()
        {
            CreateMap<SlikRequest, SlikRequestSummaryPut>().ReverseMap();
            CreateMap<SlikRequest, SlikRequestSummaryResponse>().ReverseMap();
        }
    }
}
