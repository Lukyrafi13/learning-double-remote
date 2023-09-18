using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationBusinessProfile : Profile
    {
        public LoanApplicationVerificationBusinessProfile()
        {
            CreateMap<LoanApplicationVerificationBusiness, LoanApplicationVerificationBusinessResponse>();
            CreateMap<LoanApplicationVerificationBusinessPostRequest, LoanApplicationVerificationBusiness>();
        }
    }
}
