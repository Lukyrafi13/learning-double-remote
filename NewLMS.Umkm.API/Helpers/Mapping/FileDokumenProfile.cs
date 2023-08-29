using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.FileDokumens;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
