using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;
using System;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationSurveyProfile : Profile
    {
        public LoanApplicationSurveyProfile()
        {
            CreateMap<LoanApplication, LoanApplicationSurveyResponse>()
                .ForMember(d => d.LoanApplicationInfo, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplication());
                })
                .ForMember(d => d.LoanApplicationFieldSurvey, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFieldSurvey);
                })
                .ForMember(d => d.LoanApplicationVerificationBusiness, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationBusiness);
                })
                .ForMember(d => d.LoanApplicationVerificationCycle, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationCycle);
                })
                ;


            //App Info
            CreateMap<LoanApplication, LoanApplicationAppInfoApprSurveyorResponse>()
                .ForMember(d => d.Regency, o =>
                {
                    o.MapFrom(s => s.RfBranch.Name);
                })
                .ForMember(d => d.Branch, o =>
                {
                    o.MapFrom(s => s.RfBranch.Code + " - "+ s.RfBranch.Name);
                })
                .ForMember(d => d.AccountOfficer, o =>
                {
                    o.MapFrom(s => s.Owner.Nama);
                })
                .ForMember(d => d.Product, o =>
                {
                    o.MapFrom(s => "BJB " + s.RfProduct.ProductType);
                })
                .ForMember(d => d.BookingOffice, o =>
                {
                    o.MapFrom(s => s.RfBookingBranch.Code + " - " + s.RfBookingBranch.Name);
                })
                .ForMember(d => d.Name, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.Name : s.Debtor.Fullname);
                })
                .ForMember(d => d.NoIdentity, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? "-" : s.Debtor.NoIdentity);
                })
                .ForMember(d => d.NPWP, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? "-" : s.Debtor.NPWP);
                })
                .ForMember(d => d.DateOfBirth, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.DateOfBirth);
                })
                .ForMember(d => d.IsBusinessCycle, o =>
                {
                    o.MapFrom(s => s.IsBusinessCycle);
                })
                ;


            //Base Tab
            CreateMap<LoanApplication, LoanApplicationSurveyTabRespone>()
                .ForMember(d => d.RequestDate, o =>
                {
                    o.MapFrom(s => DateTime.Now);
                })
                .ForMember(d => d.SlikStatus, o =>
                {
                    o.MapFrom(s => "1/1");
                })
                .ForMember(d => d.DebtorName, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.Name : s.Debtor.Fullname);
                })
                .ForMember(d => d.DebtorDateOfBirth, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.DateOfBirth);
                })
                ;
        }
    }
}
