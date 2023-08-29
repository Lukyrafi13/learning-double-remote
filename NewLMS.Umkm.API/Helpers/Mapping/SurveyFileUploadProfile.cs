using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SurveyFileUploads;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SurveyFileUploadProfile : Profile
    {
        public SurveyFileUploadProfile()
        {
            CreateMap<SurveyFileUploadPostRequestDto, SurveyFileUpload>();
            CreateMap<SurveyFileUploadPutRequestDto, SurveyFileUpload>();
            CreateMap<SurveyFileUploadResponseDto, SurveyFileUpload>().ReverseMap();
        }
    }
}