using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationCollateralOwnerProfile : Profile
    {
        public LoanApplicationCollateralOwnerProfile()
        {
            CreateMap<LoanApplicationCollateralOwner, LoanApplicationCollateralOwnerResponse>();
            CreateMap<LoanApplicationCollateralOwnerRequest, LoanApplicationCollateralOwner>();
        }
    }
}
