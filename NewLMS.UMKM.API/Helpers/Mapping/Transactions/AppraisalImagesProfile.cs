using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalImages;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
