using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SPPKs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class SPPKProfile : Profile
    {
        public SPPKProfile()
        {
            CreateMap<SPPK, SPPKHalamanUtamaPut>().ReverseMap();
            CreateMap<SPPK, SPPKHalamanUtamaResponse>().ReverseMap();
        }
    }
}
