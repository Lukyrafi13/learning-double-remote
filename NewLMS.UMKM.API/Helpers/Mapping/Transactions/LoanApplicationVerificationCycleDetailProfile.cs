using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationCycleDetails;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationCycleDetailProfile : Profile
    {
        public LoanApplicationVerificationCycleDetailProfile()
        {
            CreateMap<LoanApplicationVerificationCycleDetail, LoanApplicationVerificationCycleDetailResponse>();
            CreateMap<LoanApplicationVerificationCycleDetailPostRequest, LoanApplicationVerificationCycleDetail>();
            CreateMap<LoanApplicationVerificationCycleDetailPutRequest, LoanApplicationVerificationCycleDetail>();
            CreateMap<LoanApplicationVerificationCycleDetailDeleteRequest, LoanApplicationVerificationCycleDetail>();
        }
    }
}
