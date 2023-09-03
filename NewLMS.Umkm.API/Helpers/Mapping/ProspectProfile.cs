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
        }
    }
}