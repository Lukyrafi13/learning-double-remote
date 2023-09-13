using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationRACs;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationRACProfile : Profile
    {
        public LoanApplicationRACProfile()
        {
            CreateMap<LoanApplicationRAC, LoanApplicationRACsResponse>();
        }
    }
}
