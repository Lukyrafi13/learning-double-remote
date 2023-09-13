using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorCompany;
using NewLMS.UMKM.Data.Dto.DebtorCompanyLegal;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorCompanyProfile : Profile
    {
        public DebtorCompanyProfile()
        {
            CreateMap<DebtorCompany, DebtorCompanyResponse>();
            CreateMap<DebtorCompanyLegal, DebtorCompanyLegalResponse>();
            CreateMap<DebtorCompanyRequest, DebtorCompany>();
            CreateMap<LoanApplicationIDEUpsertRequest, DebtorCompany>()
                .ConstructUsing((s, c) => c.Mapper.Map<DebtorCompany>(s.DataPermohonan.DebtorCompany));
        }
    }
}

