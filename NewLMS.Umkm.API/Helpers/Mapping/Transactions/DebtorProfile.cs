using System;
using AutoMapper;
using NewLMS.UMKM.Data.Dto.Debtor;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorProfile : Profile
    {
        public DebtorProfile()
        {
            CreateMap<Debtor, DebtorResponse>();
            CreateMap<Debtor, DebtorSimpleResponse>();
            CreateMap<DebtorPostRequest, Debtor>();
        }
    }
}

