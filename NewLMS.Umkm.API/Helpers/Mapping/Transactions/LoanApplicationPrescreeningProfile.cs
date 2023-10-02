using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.RfTenor;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationPrescreeningProfile : Profile
    {
        public LoanApplicationPrescreeningProfile()
        {
            CreateMap<LoanApplication, LoanApplicationPrescreeningsTableResponse>()
                .ForMember(d => d.Id, o =>
                {
                    o.MapFrom(s => s.Id);
                })
                .ForMember(d => d.DebtorName, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.Fullname : s.DebtorCompany.Name);
                })
                .ForMember(d => d.DebtorDateOfBirth, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.DateOfBirth : null);
                })
                .ForMember(d => d.SlikStatus, o =>
                {
                    o.MapFrom(s => "1/1");
                })
                .ForMember(d => d.RequestDate, o =>
                {
                    o.MapFrom(s => DateTime.Now);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationPrescreeningResponse>()
                .ForMember(d => d.InfoPrescreening, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplication());
                })
                .ForMember(d => d.LoanApplicationRAC, o =>
                {
                    o.MapFrom(s => s.LoanApplicationRAC);
                })
                .ForMember(d => d.LoanApplicationCollaterals, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollaterals);
                })
                ;

            CreateMap<LoanApplicationCollateral, LoanApplicationCollateralResponse>();

            CreateMap<LoanApplication, LoanApplicationPrescreeningBaseTabReponse>();

            CreateMap<LoanApplication, LoanApplicationPrescreeningInfoResponse>()
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
                .ForMember(d => d.DebtorAge, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : MediatR.Helpers.HelperGeneral.CalculateAge(s.Debtor.DateOfBirth));
                })
                .ForMember(d => d.DebtorAgePlusTenor, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : (MediatR.Helpers.HelperGeneral.CalculateAge(s.Debtor.DateOfBirth)) + (s.LoanApplicationFacilities.Sum(facility => facility.RfTenor.Tenor)/12));
                })
                .ForMember(d => d.RfMarital, o =>
                {
                    o.MapFrom(s => s.OwnerCategoryId == 2 ? null : s.Debtor.RfMarital);
                })
                .ForMember(d => d.DuplicationsVerified, o =>
                {
                    o.MapFrom(s => s.DuplicationsVerified);
                })
                ;

            CreateMap<LoanApplicationPrescreeningDuplicationRequest, LoanApplication>();
        }
    }
}
