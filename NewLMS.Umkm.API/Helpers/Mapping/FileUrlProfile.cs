using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.FileUrls;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class FileUrlProfile : Profile
    {
        public FileUrlProfile()
        {
            CreateMap<FileUrlPostRequestDto, FileUrl>();
            CreateMap<FileUrlPutRequestDto, FileUrl>();
            CreateMap<FileUrlResponseDto, FileUrl>().ReverseMap();
        }
    }
}