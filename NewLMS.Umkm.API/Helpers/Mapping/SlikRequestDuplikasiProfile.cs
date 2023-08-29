using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.MSearchs;
// using NewLMS.Umkm.Data.Dto.SlikRequestDuplikasis;

namespace NewLMS.Umkm.API.Helpers.Mapping

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