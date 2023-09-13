using System;
using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorEmergencies;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorEmergencyProfile : Profile
    {
        public DebtorEmergencyProfile()
        {
            CreateMap<DebtorEmergency, DebtorEmergencyResponse>();
            CreateMap<DebtorEmergencyRequest, DebtorEmergency>();
            CreateMap<LoanApplicationIDEUpsertRequest, DebtorEmergency>()
                .ConstructUsing((s, c) => c.Mapper.Map<DebtorEmergency>(s.DataPermohonan.DebtorEmergency));
        }
    }
}

