using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorCouple;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
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
                })
                .ForMember(d => d.RfMarital, o =>
                {
                    o.MapFrom(s => s.RfMarital);
                });

            CreateMap<DebtorCoupleRequest, DebtorCouple>();
        }
    }
}

