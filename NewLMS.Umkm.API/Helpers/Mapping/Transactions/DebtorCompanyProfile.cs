using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorCompany;
using NewLMS.UMKM.Data.Dto.DebtorCompanyLegal;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorCompanyProfile:Profile
	{
		public DebtorCompanyProfile()
		{
			//DebtorCompany
			CreateMap<DebtorCompany, DebtorCompanyResponse>();
			CreateMap<DebtorCompany, DebtorCompanySimpleResponse>();
			CreateMap<DebtorCompanyPostRequest, DebtorCompany>();

			//DebtorCompanyLegal
            CreateMap<DebtorCompanyLegal, DebtorCompanyLegalResponse>();
            CreateMap<DebtorCompanyLegalPostRequest, DebtorCompanyLegal>();
        }
	}
}

