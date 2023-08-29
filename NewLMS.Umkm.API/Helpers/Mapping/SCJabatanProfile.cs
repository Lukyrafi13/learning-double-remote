using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SCJabatans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SCJabatanProfile : Profile
    {
        public SCJabatanProfile()
        {
            CreateMap<SCJabatan, SCJabatanResponseDto>().ReverseMap();
            CreateMap<SCJabatanPostRequestDto, SCJabatan>();
            CreateMap<SCJabatanPutRequestDto, SCJabatan>();
        }
    }
}