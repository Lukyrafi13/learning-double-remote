using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.MSearchs;
// using NewLMS.UMKM.Data.Dto.SlikRequestDuplikasis;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SlikRequestDuplikasiProfile : Profile
    {
        public SlikRequestDuplikasiProfile()
        {
            // CreateMap<SlikRequestDuplikasi, SlikRequestDuplikasiResponseDto>().ReverseMap();
            // CreateMap<SlikRequestDuplikasiPostRequestDto, SlikRequestDuplikasi>();
            // CreateMap<SlikRequestDuplikasiPutRequestDto, SlikRequestDuplikasi>();

            CreateMap<SlikRequestDuplikasi, MSearchResponse>().ReverseMap();

        }
    }
}