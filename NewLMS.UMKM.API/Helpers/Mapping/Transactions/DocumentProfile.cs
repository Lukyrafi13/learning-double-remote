using AutoMapper;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentResponse>()
                .ForMember(d => d.Files, s => s.MapFrom(d => d.Files));

            CreateMap<DocumentFileUrl, DocumentFileUrlRes>()
                .ForMember(d => d.Id, s => s.MapFrom(d => d.Id));

            CreateMap<DocumentUploadRequest, Document>();
            CreateMap<DocumentUpdateRequest, Document>();
            CreateMap<DocumentDeleteRequest, Document>();
            CreateMap<FileDeleteRequest, Document>();

            //DocumentFileUrl
            CreateMap<DocumentFileUrl, DocumentFileUrlRes>();

            //FileUrl
            CreateMap<FileUrl, FileRes>();
        }
    }
}
