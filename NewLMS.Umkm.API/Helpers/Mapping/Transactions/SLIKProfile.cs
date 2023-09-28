using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class SLIKProfile : Profile
    {
        public SLIKProfile()
        {
            CreateMap<SLIKRequestDebtor, SLIKRequestDebtorResponse>()
                .ForMember(d => d.RfSLIKDebtorType, o => o.MapFrom(s => s.RfSLIKDebtorType))
                .ForMember(d => d.FileUrl, o => o.MapFrom(s => s.FileUrl));
            CreateMap<SLIKRequest, SLIKRequestTableResponse>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.LoanApplication.RfBookingBranch))
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory.Code == "002" ? s.LoanApplication.DebtorCompany.Name : s.LoanApplication.Debtor.Fullname))
                .ForMember(d => d.LoanApplicationId, o => o.MapFrom(s => s.LoanApplication.LoanApplicationId))
                .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.SLIKRequestDebtors, o => o.MapFrom(s => s.SLIKRequestDebtors));
            //CreateMap<LoanApplication, SLIKRequest>();
            CreateMap<SLIKRequestDebtorRequest, SLIKRequestDebtor>();

            CreateMap<SLIKRequest, SLIKRequestResponse>()
                .ForMember(d => d.Comment, o => o.MapFrom(s => s.Comment))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.ReadAndUnderstand, o => o.MapFrom(s => s.ReadAndUnderstand))
                .ForMember(d => d.ProcessDate, o => o.MapFrom(s => s.ProcessDate))
                .ForMember(d => d.AdminVerified, o => o.MapFrom(s => s.AdminVerified))
                .ForMember(d => d.TotalCreditCard, o => o.MapFrom(s => s.TotalCreditCard))
                .ForMember(d => d.TotalLimitSlik, o => o.MapFrom(s => s.TotalLimitSlik))
                .ForMember(d => d.TotalOtherUses, o => o.MapFrom(s => s.TotalOtherUses))
                .ForMember(d => d.TotalWorkingCapital, o => o.MapFrom(s => s.TotalWorkingCapital))
                .ForMember(d => d.InquiryDate, o => o.MapFrom(s => s.InquiryDate))
                .ForMember(d => d.RfStage, o => o.MapFrom(s => s.LoanApplication.RfStage))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.LoanApplication.RfBookingBranch))
                .ForMember(d => d.SLIKRequestDebtors, o => o.MapFrom(s => s.SLIKRequestDebtors));
            .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
        }
    }
}

