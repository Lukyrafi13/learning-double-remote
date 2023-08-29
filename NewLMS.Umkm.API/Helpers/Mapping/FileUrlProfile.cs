using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.FileUrls;

namespace NewLMS.UMKM.API.Helpers.Mapping

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