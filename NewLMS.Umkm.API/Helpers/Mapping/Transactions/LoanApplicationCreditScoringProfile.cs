using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditScoring;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationCreditScoringProfile : Profile
    {
        public LoanApplicationCreditScoringProfile()
        {
            CreateMap<LoanApplicationCreditScoring, LoanApplicationCreditScoringResponse>()
                .ForMember(d => d.ScoResidentialReputation, o =>
                {
                    o.MapFrom(s => s.ScoResidentialReputation);
                })
                .ForMember(d => d.ScoMonthlyMutation, o =>
                {
                    o.MapFrom(s => s.ScoMonthlyMutation);
                })
                .ForMember(d => d.ScoBankRelation, o =>
                {
                    o.MapFrom(s => s.ScoBankRelation);
                })
                .ForMember(d => d.ScoBJBCreditHistory, o =>
                {
                    o.MapFrom(s => s.ScoBJBCreditHistory);
                })
                .ForMember(d => d.ScoTransacMethod, o =>
                {
                    o.MapFrom(s => s.ScoTransacMethod);
                })
                .ForMember(d => d.ScoAverageAccBalance, o =>
                {
                    o.MapFrom(s => s.ScoAverageAccBalance);
                })
                .ForMember(d => d.ScoNeedLevel, o =>
                {
                    o.MapFrom(s => s.ScoNeedLevel);
                })
                .ForMember(d => d.ScoFinanceManager, o =>
                {
                    o.MapFrom(s => s.ScoFinanceManager);
                })
                .ForMember(d => d.ScoBusinesLocation, o =>
                {
                    o.MapFrom(s => s.ScoBusinesLocation);
                })
                .ForMember(d => d.ScoOtherPartyDebt, o =>
                {
                    o.MapFrom(s => s.ScoOtherPartyDebt);
                })
                .ForMember(d => d.ScoCollateral, o =>
                {
                    o.MapFrom(s => s.ScoCollateral);
                });
            CreateMap<LoanApplicationCreditScoringPostRequest, LoanApplicationCreditScoring>();
        }
    }
}
