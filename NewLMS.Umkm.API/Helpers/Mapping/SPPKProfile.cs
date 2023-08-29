using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SPPKs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
