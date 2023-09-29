using AutoMapper;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class DocumentSurveyProfile : Profile
    {
        public DocumentSurveyProfile()
        {
            CreateMap<Document, DocumentSurveyResponse>();
            CreateMap<DocumentSurveyUploadRequest, Document>();
            CreateMap<DocumentSurveyDeleteRequest, Document>();
        }
    }
}
