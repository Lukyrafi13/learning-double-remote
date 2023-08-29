using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.FileDokumens;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class FileDokumenProfile : Profile
    {
        public FileDokumenProfile()
        {
            CreateMap<FileDokumenPostRequestDto, FileDokumen>();
            CreateMap<FileDokumenPutRequestDto, FileDokumen>();
            CreateMap<FileDokumenResponseDto, FileDokumen>().ReverseMap();
        }
    }
}
