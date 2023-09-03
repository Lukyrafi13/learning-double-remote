using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.Prospects;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class ProspectProfile : Profile
    {
        public ProspectProfile()
        {
            CreateMap<ProspectPostRequest, Prospect>();
            CreateMap<ProspectPutRequest, Prospect>();
            CreateMap<Prospect, ProspectResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(s => s.RfProduct));

            CreateMap<Prospect, ProspectTableResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(s => s.RfProduct));
        }
    }
}