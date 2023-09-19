using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalProductiveLands;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprProductiveLandTemplateProfile : Profile
    {
        public ApprProductiveLandTemplateProfile()
        {
            CreateMap<ApprProductiveLandTemplate, ApprProductiveLandTemplateResponse>();
        }
    }
}
