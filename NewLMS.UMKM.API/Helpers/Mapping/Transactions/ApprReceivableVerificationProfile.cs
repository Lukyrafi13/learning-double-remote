using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalReceivable;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprReceivableVerificationProfile : Profile
    {
        public ApprReceivableVerificationProfile()
        {
            CreateMap<ApprReceivableVerification, ApprReceivableVerificationResponse>();
        }
    }
}
