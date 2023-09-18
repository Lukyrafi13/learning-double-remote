using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationCycles;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationCycleProfile : Profile
    {
        public LoanApplicationVerificationCycleProfile()
        {
            CreateMap<LoanApplicationVerificationCycle, LoanApplicationVerificationCyclesResponse>();
            CreateMap<LoanApplicationVerificationCyclesPostRequest, LoanApplicationVerificationCycle>();
        }
    }
}
