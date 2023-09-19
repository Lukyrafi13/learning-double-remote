using AutoMapper;
using NewLMS.Umkm.Data.Dto.DebtorCouple;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class DebtorCoupleProfile : Profile
    {
        public DebtorCoupleProfile()
        {
            CreateMap<DebtorCouple, DebtorCoupleResponse>()
                .ForMember(d => d.RfZipCode, o =>
                {
                    o.MapFrom(s => s.RfZipCode);
                })
                .ForMember(d => d.RfJob, o =>
                {
                    o.MapFrom(s => s.RfJob);
                });

            CreateMap<DebtorCoupleRequest, DebtorCouple>();
            CreateMap<LoanApplicationIDEUpsertRequest, DebtorCouple>()
                .ConstructUsing((s, c) => c.Mapper.Map<DebtorCouple>(s.DataPermohonan.DebtorCouple));
        }
    }
}

