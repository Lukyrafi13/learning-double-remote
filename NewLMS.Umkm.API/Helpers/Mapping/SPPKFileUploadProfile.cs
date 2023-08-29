using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SPPKFileUploads;

namespace NewLMS.UMKM.API.Helpers.Mapping

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