using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SCJabatans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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