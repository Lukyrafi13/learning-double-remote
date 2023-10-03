using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Dto.RfSubProducts;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Linq;

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
                .ForMember(d => d.LoanApplicationVerificationNeed, o =>
                {
                    o.MapFrom(s => s.LoanApplicationVerificationNeed);
                })
                ;


            //App Info
            CreateMap<LoanApplication, LoanApplicationAppInfoSurveyResponse>()
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
                .ForMember(d => d.RfSubProduct, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.First().RfSubProduct);
                })
                .ForMember(d => d.PlacementCountryCode, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.First().PlacementCountryCode);
                })
                .ForMember(d => d.RfPlacementCountry, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.First().RfPlacementCountry);
                })
                .ForMember(d => d.ApplicationTypeId, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.First().ApplicationTypeId) ;
                })
                .ForMember(d => d.ApplicationType, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.First().ApplicationType);
                })
                ;



            CreateMap<LoanApplication, LoanApplicationAppInfoAppraisalSurveyorResponse>()
               .ForMember(d => d.RfOwnerCategory, o =>
               {
                   o.MapFrom(s => s.RfOwnerCategory);
               })
                /*.ForMember(d => d.Branch, o =>
               {
                   o.MapFrom(s => s.RfBranch.Code + " - " + s.RfBranch.Name);
               })
               .ForMember(d => d.SubProduct, o =>
               {
                   o.MapFrom(s => s.LoanApplicationFacilities.First().RfSubProduct.SubProductDesc);
               })
               .ForMember(d => d.Name, o =>
               {
                   o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.Name : s.Debtor.Fullname);
               })
               .ForMember(d => d.SIUPDate, o =>
               {
                   o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.DebtorCompanyLegal.SIUPDate.ToString() : null);
               })
               .ForMember(d => d.Branch, o =>
               {
                   o.MapFrom(s => s.RfBranch.Code + " - " + s.RfBranch.Name);
               })
               .ForMember(d => d.SIUPNumber, o =>
               {
                   o.MapFrom(s => s.DebtorCompany.DebtorCompanyLegal.SIUPNumber);
               })
               .ForMember(d => d.CompanyOld, o =>
               {
                   o.MapFrom(s => "-");
               })
               .ForMember(d => d.Address, o =>
               {
                   o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.Address : s.Debtor.Address);
               })
               .ForMember(d => d.PhoneNumber, o =>
               {
                   o.MapFrom(s => s.OwnerCategoryId == 2 ? s.DebtorCompany.PhoneNumber : s.Debtor.PhoneNumber);
               })
               .ForMember(d => d.NPWP, o =>
               {
                   o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.NPWP);
               })*/
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
