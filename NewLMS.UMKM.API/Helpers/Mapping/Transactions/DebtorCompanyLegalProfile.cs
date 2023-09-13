using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorCompanyLegal;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorCompanyLegalProfile : Profile
    {
        public DebtorCompanyLegalProfile()
        {
            CreateMap<DebtorCompanyLegal, DebtorCompanyLegalResponse>();
            CreateMap<DebtorCompanyLegalRequest, DebtorCompanyLegal>();
            CreateMap<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>()
                .ConstructUsing((s, c) => c.Mapper.Map<DebtorCompanyLegal>(s.DataPermohonan.DebtorCompanyLegal));
        }
    }
}

