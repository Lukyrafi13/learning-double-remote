using AutoMapper;
using NewLMS.Umkm.Data.Dto.DebtorCompanyLegal;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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

