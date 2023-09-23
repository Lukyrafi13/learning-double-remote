using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
