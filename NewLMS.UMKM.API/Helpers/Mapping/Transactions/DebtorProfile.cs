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
            CreateMap<Debtor, DebtorResponse>()
                .ForMember(d => d.DebtorCouple, o =>
                {
                    o.MapFrom(s => s.DebtorCouple);
                })
                .ForMember(d => d.RfResidenceStatus, o =>
                {
                    o.MapFrom(s => s.RfResidenceStatus);
                })
                .ForMember(d => d.RfZipCode, o =>
                {
                    o.MapFrom(s => s.RfZipCode);
                })
                .ForMember(d => d.RfJob, o =>
                {
                    o.MapFrom(s => s.RfJob);
                })
                .ForMember(d => d.RfGender, o =>
                {
                    o.MapFrom(s => s.RfGender);
                })
                .ForMember(d => d.RfEducation, o =>
                {
                    o.MapFrom(s => s.RfEducation);
                })
                .ForMember(d => d.RfMarital, o =>
                {
                    o.MapFrom(s => s.RfMarital);
                });

            CreateMap<DebtorRequest, Debtor>();
            CreateMap<LoanApplicationIDEUpsertRequest, Debtor>()
                .ConstructUsing((s, c) => c.Mapper.Map<Debtor>(s.DataPermohonan.Debtor));

        }
    }
}

