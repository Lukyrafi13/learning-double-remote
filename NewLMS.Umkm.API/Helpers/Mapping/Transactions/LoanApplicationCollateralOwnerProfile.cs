using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
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
