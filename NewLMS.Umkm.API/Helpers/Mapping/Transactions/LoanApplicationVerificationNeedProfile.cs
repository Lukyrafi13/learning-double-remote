using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeeds;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationNeedProfile : Profile
    {
        public LoanApplicationVerificationNeedProfile()
        {
            CreateMap<LoanApplicationVerificationNeed, LoanApplicationVerificationNeedsResponse>();
            CreateMap<LoanApplicationVerificationNeedsRequest, LoanApplicationVerificationNeed>();
        }
    }
}
