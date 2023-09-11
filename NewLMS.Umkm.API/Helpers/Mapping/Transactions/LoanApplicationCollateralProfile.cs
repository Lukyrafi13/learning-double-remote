using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationCollateralProfile : Profile
    {
        public LoanApplicationCollateralProfile()
        {
            CreateMap<LoanApplicationCollateral, LoanApplicationCollateralResponse>();
            CreateMap<LoanApplicationCollateralRequest, LoanApplicationCollateral>();
            CreateMap<LoanApplicationCollateralRequest, LoanApplicationCollateralOwner>();
            CreateMap<LoanApplicationCollateralAndOwnerPostRequest, LoanApplicationCollateral>()
                .ForMember(d => d.LoanApplicationCollateralOwner, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollateralOwner);
                });

            CreateMap<LoanApplicationCollateralPutRequest, LoanApplicationCollateral>();
            CreateMap<LoanApplicationCollateralAndOwnerPutRequest, LoanApplicationCollateral>()
                .ForMember(d => d.LoanApplicationCollateralOwner, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollateralOwner);
                });

            CreateMap<LoanApplicationCollateralDeleteRequest, LoanApplicationCollateral>();
        }
    }
}
