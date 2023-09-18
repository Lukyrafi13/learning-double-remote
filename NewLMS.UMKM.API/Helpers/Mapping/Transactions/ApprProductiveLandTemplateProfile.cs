using AutoMapper;
using NewLMS.UMKM.Data.Dto.AppraisalProductiveLands;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprProductiveLandTemplateProfile : Profile
    {
        public ApprProductiveLandTemplateProfile()
        {
            CreateMap<ApprProductiveLandTemplate, ApprProductiveLandTemplateResponse>();
        }
    }
}
