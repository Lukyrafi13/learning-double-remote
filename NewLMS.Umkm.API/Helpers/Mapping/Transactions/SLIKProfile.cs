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
                .ForMember(d => d.ApplicationStatus, o => o.MapFrom(s => s.Status == Data.Enums.EnumSLIKStatus.Draft ? "Belum Dirposes" : s.AdminVerified ? "Sudah Diproses" : "Sedang Diproses"))
                .ForMember(d => d.NoIdentity, o => o.MapFrom(s => s.LoanApplication.Debtor.NoIdentity))
                .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.SLIKRequestDebtors, o => o.MapFrom(s => s.SLIKRequestDebtors));
            //CreateMap<LoanApplication, SLIKRequest>();
            CreateMap<SLIKRequestDebtorRequest, SLIKRequestDebtor>();

            CreateMap<SLIKRequest, SLIKInfoResponse>()
                .ForMember(d => d.AccountOfficer, o => o.MapFrom(s => s.LoanApplication.Prospect.AccountOfficer))
                .ForMember(d => d.BookingBranch, o => o.MapFrom(s => s.LoanApplication.RfBookingBranch))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.LoanApplication.Debtor.DateOfBirth))
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory.Code == "001" ? s.LoanApplication.Debtor.Fullname : s.LoanApplication.DebtorCompany.Name))
                .ForMember(d => d.LoanApplicationId, o => o.MapFrom(s => s.LoanApplication.LoanApplicationId))
                .ForMember(d => d.NoIdentity, o => o.MapFrom(s => s.LoanApplication.Debtor.NoIdentity))
                .ForMember(d => d.NPWP, o => o.MapFrom(s => s.LoanApplication.Debtor.NPWP))
                .ForMember(d => d.OwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.RfProduct, o => o.MapFrom(s => s.LoanApplication.RfProduct));

            CreateMap<SLIKRequest, SLIKRequestResponse>()
                .ForMember(d => d.Info, o => o.MapFrom(s => s ?? new SLIKRequest()))
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
                .ForMember(d => d.RfStage, o => o.MapFrom(s => s.RfStage))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch))
                .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.LoanApplication, o => o.MapFrom(s => s.LoanApplication))
                .ForMember(d => d.SLIKRequestDebtors, o => o.MapFrom(s => s.SLIKRequestDebtors));
        }
    }
}

