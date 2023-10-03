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
            CreateMap<LoanApplicationCreditHistory, LoanApplicationCreditHistoryResponse>();
        }
    }
}

