using System;
using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationCreditHistoryProfile : Profile
    {
        public LoanApplicationCreditHistoryProfile()
        {
            CreateMap<LoanApplicationCreditHistory, LoanApplicationCreditHistoryResponse>()
                .ForMember(d => d.EconomoySectorDetail, s => s.MapFrom(d => d.RfSandiBIEconomySectorClass))
                .ForMember(d => d.BehaviourDetail, s => s.MapFrom(d => d.RfSandiBIBehaviourClass))
                .ForMember(d => d.ApplicationTypeDetail, s => s.MapFrom(d => d.RfSandiBIApplicationTypeClass))
                .ForMember(d => d.CollectibilityDetail, s => s.MapFrom(d => d.RfSandiBICollectibilityClass))
                .ForMember(d => d.BankDetail, s => s.MapFrom(d => d.RfBank))
                .ForMember(d => d.RfCondition, s => s.MapFrom(d => d.RfCondition))
                .ForMember(d => d.CreditTypeDetail, s => s.MapFrom(d => d.RfCreditType));
            CreateMap<LoanApplicationCreditHistoryPostRequest, LoanApplicationCreditHistory>();
            CreateMap<LoanApplicationCreditHistoryPutRequest, LoanApplicationCreditHistory>();
        }
    }
}

