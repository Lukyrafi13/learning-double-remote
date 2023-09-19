using System;
using AutoMapper;
using NewLMS.Umkm.Data.Dto.DebtorEmergencies;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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

