using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
