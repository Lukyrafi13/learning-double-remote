using AutoMapper;
using NewLMS.UMKM.Data.Dto.AppraisalReceivable;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprReceivableVerificationProfile : Profile
    {
        public ApprReceivableVerificationProfile()
        {
            CreateMap<ApprReceivableVerification, ApprReceivableVerificationResponse>();
        }
    }
}
