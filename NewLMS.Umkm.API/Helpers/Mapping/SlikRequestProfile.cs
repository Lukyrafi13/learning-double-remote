using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SlikRequests;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
