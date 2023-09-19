using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class SLIKProfile : Profile
    {
        public SLIKProfile()
        {
            CreateMap<SLIKRequestDebtor, SLIKRequestDebtorResponse>();
            CreateMap<SLIKRequest, SLIKRequestTableResponse>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.LoanApplication.RfBookingBranch))
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory.Code == "002" ? s.LoanApplication.DebtorCompany.Name : s.LoanApplication.Debtor.Fullname))
                .ForMember(d => d.LoanApplicationId, o => o.MapFrom(s => s.LoanApplication.LoanApplicationId))
                .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.SLIKRequestDebtors, o => o.MapFrom(s => s.SLIKRequestDebtors));
            //CreateMap<LoanApplication, SLIKRequest>();
        }
    }
}

