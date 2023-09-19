using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollaterals;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
