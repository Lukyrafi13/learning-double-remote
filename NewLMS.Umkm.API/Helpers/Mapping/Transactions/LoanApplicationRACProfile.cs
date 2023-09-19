using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationRACs;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationRACProfile : Profile
    {
        public LoanApplicationRACProfile()
        {
            CreateMap<LoanApplicationRAC, LoanApplicationRACsResponse>();
            CreateMap<LoanApplicationRACRequest, LoanApplicationRAC>();
        }
    }
}
