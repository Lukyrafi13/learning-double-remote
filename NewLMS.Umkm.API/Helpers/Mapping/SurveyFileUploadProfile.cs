using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SurveyFileUploads;

namespace NewLMS.Umkm.API.Helpers.Mapping

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