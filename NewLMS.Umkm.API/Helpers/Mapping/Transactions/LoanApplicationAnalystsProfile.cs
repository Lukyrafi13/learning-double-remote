using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Linq;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationAnalystsProfile : Profile
    {
        public LoanApplicationAnalystsProfile()
        {
            CreateMap<LoanApplication, LoanApplicationAnalystTableResponse>()
                .ForMember(d => d.Id, o => { o.MapFrom(s => s.Id);})
                .ForMember(d => d.LoanApplicationId, o => { o.MapFrom(s => s.LoanApplicationId);})
                .ForMember(d => d.RequestDate, o => { o.MapFrom(s => DateTime.Now);})
                .ForMember(d => d.SlikStatus, o => { o.MapFrom(s => "1/1");})
                .ForMember(d => d.DebtorName, o => { 
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.Fullname : s.DebtorCompany.Name);
                })
                .ForMember(d => d.DebtorDateOfBirth, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.DateOfBirth : null);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationAnalystReponse>()
                .ForMember(d => d.LoanApplicationAnalystAppInfo, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplication());
                })
                .ForMember(d => d.SLIKAdmin, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplication());
                })
                .ForMember(d => d.LoanApplicationRAC, o =>
                {
                    o.MapFrom(s => s.LoanApplicationRAC);
                })
                .ForMember(d => d.LoanApplicationVerificationBusiness, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationBusiness);
                })
                .ForMember(d => d.LoanApplicationVerificationCycle, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationCycle);
                })
                .ForMember(d => d.LoanApplicationVerificationNeeds, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationNeed);
                })
                .ForMember(d => d.LoanApplicationBusinessInformation, o =>
                {
                    o.MapFrom(s => s.LoanApplicationBusinessInformation);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationAnalystAppInfoResponse>()
                .ForMember(d => d.Regency, o =>
                {
                    o.MapFrom(s => s.RfBranch.KanwilName);
                })
                .ForMember(d => d.Branch, o =>
                {
                    o.MapFrom(s => s.RfBranch.Code + " - " + s.RfBranch.Name);
                })
                .ForMember(d => d.AccountOfficer, o =>
                {
                    o.MapFrom(s => s.Owner.Nama);
                })
                .ForMember(d => d.LoanApplicationId, o =>
                {
                    o.MapFrom(s => s.LoanApplicationId);
                })
                .ForMember(d => d.Product, o =>
                {
                    o.MapFrom(s => "BJB " + s.RfProduct.ProductDesc);
                })
                .ForMember(d => d.Name, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.Name : s.Debtor.Fullname);
                })
                .ForMember(d => d.NPWP, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.NPWP);
                })
                .ForMember(d => d.NoIdentity, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.NoIdentity);
                })
                .ForMember(d => d.DateOfBirth, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.DateOfBirth);
                })
                .ForMember(d => d.BookingOffice, o =>
                {
                    o.MapFrom(s => s.RfBookingBranch.Code + " - " + s.RfBookingBranch.Name);
                })
                .ForMember(d => d.IsBusinessCycle, o =>
                {
                    o.MapFrom(s => s.IsBusinessCycle);
                })
                .ForMember(d => d.RfOwnerCategory, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationAnalystSLIKAdminTabResponse>()
                .ForMember(d => d.SLIKRequestDebtors, o =>
                {
                    o.MapFrom(s => s.SLIKRequest.SLIKRequestDebtors);
                })
                .ForMember(d => d.CreditHistories, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCreditHistories);
                });

            CreateMap<LoanApplicationAnalystRequest, LoanApplication>();
        }
    }
}
