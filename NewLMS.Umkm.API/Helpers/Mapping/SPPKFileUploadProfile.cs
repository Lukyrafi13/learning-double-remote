using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SPPKFileUploads;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class SPPKFileUploadProfile : Profile
    {
        public SPPKFileUploadProfile()
        {
            CreateMap<SPPKFileUploadPostRequestDto, SPPKFileUpload>();
            CreateMap<SPPKFileUploadPutRequestDto, SPPKFileUpload>();
            CreateMap<SPPKFileUploadResponseDto, SPPKFileUpload>().ReverseMap();
        }
    }
}