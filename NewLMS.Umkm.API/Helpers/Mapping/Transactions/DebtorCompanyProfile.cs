using AutoMapper;
using NewLMS.Umkm.Data.Dto.DebtorCompany;
using NewLMS.Umkm.Data.Dto.DebtorCompanyLegal;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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

