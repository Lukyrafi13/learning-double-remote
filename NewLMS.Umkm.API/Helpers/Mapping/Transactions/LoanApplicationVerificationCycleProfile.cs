using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycles;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationCycleProfile : Profile
    {
        public LoanApplicationVerificationCycleProfile()
        {
            CreateMap<LoanApplicationVerificationCycle, LoanApplicationVerificationCycleResponse>();
            CreateMap<LoanApplicationVerificationCyclePostRequest, LoanApplicationVerificationCycle>();
        }
    }
}
