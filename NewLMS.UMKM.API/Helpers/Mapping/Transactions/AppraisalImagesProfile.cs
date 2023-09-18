using AutoMapper;
using NewLMS.UMKM.Data.Dto.AppraisalImages;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class AppraisalImagesProfile : Profile
    {
        public AppraisalImagesProfile()
        {
            CreateMap<Document, AppraisalImagesResponse>()
                .ForMember(d => d.Files, s => s.MapFrom(d => d.Files));

            CreateMap<AppraisalImagesDeleteRequest, Document>();
            CreateMap<AppraisalImagesUploadRequest, Document>();
        }
    }
}
