using AutoMapper;
using NewLMS.Umkm.Data.Dto.DocumentSurveyors;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class DocumentSurveyorProfile : Profile
    {
        public DocumentSurveyorProfile()
        {
            CreateMap<Document, DocumentSurveyorResponse>()
                .ForMember(d => d.Files, s => s.MapFrom(d => d.Files));

            CreateMap<DocumentSurveyorUploadRequest, Document>();
            CreateMap<DocumentSurveyorDeleteRequest, Document>();
        }
    }
}
