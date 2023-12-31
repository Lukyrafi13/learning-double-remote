﻿using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditScorings;
using NewLMS.Umkm.Data.Dto.LoanApplicationFacilities;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using System.Linq;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class LoanApplicationProfile : Profile
    {
        public LoanApplicationProfile()
        {
            CreateMap<LoanApplication, LoanApplicationInfoResponse>()
                .ForMember(d => d.AccountOfficerName, o => o.MapFrom(s => s.Owner.Nama))
                .ForMember(d => d.DebtorName, o => o.MapFrom(s => s.RfOwnerCategory.Code == "001" ? s.Debtor.Fullname : s.DebtorCompany.Name))
                .ForMember(d => d.LoanApplicationId, o => o.MapFrom(s => s.LoanApplicationId))
                .ForMember(d => d.RfBookingBranch, o => o.MapFrom(s => s.RfBookingBranch))
                .ForMember(d => d.RfProduct, o => o.MapFrom(s => s.RfProduct));

            CreateMap<LoanApplication, LoanApplicationTableResponse>()
                .ForMember(d => d.DebtorName, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.Code == "002" ? s.DebtorCompany.Name : s.Debtor.Fullname);
                })
                .ForMember(d => d.OwnerCategory, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.Description);
                })
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.RfProduct.ProductDesc));

            CreateMap<LoanApplication, LoanApplicationDataFasilitasTabResponse>()
                .ForMember(d => d.RfOwnerCategory, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory);
                })
                .ForMember(d => d.RfBusinessCycle, o =>
                {
                    o.MapFrom(s => s.RfBusinessCycle);
                })
                .ForMember(d => d.RfProduct, o =>
                {
                    o.MapFrom(s => s.RfProduct);
                })
                .ForMember(d => d.RfBranch, o =>
                {
                    o.MapFrom(s => s.RfBranch);
                })
                .ForMember(d => d.RfBookingBranch, o =>
                {
                    o.MapFrom(s => s.RfBookingBranch);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationDataPermohonanTabResponse>()
                .ForMember(d => d.Debtor, o =>
                {
                    o.MapFrom(s => s.Debtor);
                })
                .ForMember(d => d.DebtorCompany, o =>
                {
                    o.MapFrom(s => s.DebtorCompany);
                })
                .ForMember(d => d.DebtorEmergency, o =>
                {
                    o.MapFrom(s => s.DebtorEmergency);
                });

            CreateMap<LoanApplication, LoanApplicationDataKeyPersonTabResponse>()
                .ForMember(d => d.LoanApplicationKeyPersons, o =>
                {
                    o.MapFrom(s => s.LoanApplicationKeyPersons);
                });

            CreateMap<LoanApplication, LoanApplicationDataAgunanTabResponse>()
                .ForMember(d => d.LoanApplicationCollaterals, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollaterals);
                });

            CreateMap<LoanApplication, LoanApplicationInformasiFasilitasTabResponse>()
                .ForMember(d => d.LoanApplicationFacilities, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities);
                })
                .ForMember(d => d.DeicisionMaker, o =>
                {
                    o.MapFrom(s => s.DecisionMaker);
                })
                .ForMember(d => d.RfBusinessCycle, o =>
                {
                    o.MapFrom(s => s.RfBusinessCycle);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationIDEResponse>()
                .ForMember(d => d.Info, o =>
                {
                    o.MapFrom(s => s);
                })
                .ForMember(d => d.InitialData, o =>
                {
                    o.MapFrom(s => s.MappingTab == "initial_data_entry" ? s : null);
                })
                .ForMember(d => d.DataPermohonan, o =>
                {
                    o.MapFrom(s => s.MappingTab == "data_permohonan" ? s : null);
                })
                .ForMember(d => d.KeyPerson, o =>
                {
                    o.MapFrom(s => s.MappingTab == "key_person" ? s : null);
                })
                .ForMember(d => d.DataAgunan, o =>
                {
                    o.MapFrom(s => s.MappingTab == "data_agunan" ? s : null);
                })
                .ForMember(d => d.InformasiFasilitas, o =>
                {
                    o.MapFrom(s => s.MappingTab == "informasi_fasilitas" ? s : null);
                });

            CreateMap<LoanApplication, LoanApplicationBaseTabResponse>()
                .ForMember(d => d.RfBookingBranch, o =>
                {
                    o.MapFrom(s => s.RfBookingBranch);
                })
                .ForMember(d => d.RfProduct, o =>
                {
                    o.MapFrom(s => s.RfProduct);
                })
                .ForMember(d => d.RfOwnerCategory, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory);
                })
                .ForMember(d => d.Owner, o =>
                {
                    o.MapFrom(s => s.Owner);
                });

            #region Requests
            CreateMap<LoanApplicationDataFasilitasRequest, LoanApplication>();
            CreateMap<LoanApplicationIDEUpsertRequest, LoanApplication>()
                .ConstructUsing((s, c) => c.Mapper.Map<LoanApplication>(s.InitialDataEntry.DataFasilitas))
                .ForMember(d => d.BookingBranchId, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.BookingBranchId))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.ProductId))
                .ForMember(d => d.OwnerCategoryId, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.OwnerCategoryId))
                .ForMember(d => d.IsBusinessCycle, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.IsBusinessCycle))
                .ForMember(d => d.BusinessCycleId, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.BusinessCycleId))
                .ForMember(d => d.BusinessCycleMonth, o => o.MapFrom(s => s.InitialDataEntry.DataFasilitas.BusinessCycleMonth))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.AppId));
            #endregion

            #region Relatives
            CreateMap<LoanApplicationCollateral, LoanApplicationCollateralResponse>();
            CreateMap<LoanApplicationCreditScoring, LoanApplicationCreditScoringResponse>();
            CreateMap<LoanApplicationCollateralOwner, LoanApplicationCollateralOwnerResponse>();
            CreateMap<LoanApplicationKeyPerson, LoanApplicationKeyPersonResponse>();
            CreateMap<LoanApplicationFacility, LoanApplicationFacilityResponse>();

            CreateMap<LoanApplication, SIKPRequest>()
                // Jumlah kredit (Get total kredit fasilitas yg KUR)
                // No Hp
                .ForMember(d => d.DebtorCompanyPhone, o =>
                {
                    o.MapFrom(s => s.Debtor != null ? s.Debtor.PhoneNumber : s.DebtorCompany.PhoneNumber);
                })
                .ForMember(d => d.DebtorCompanyCreditValue, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.Sum(x => x.RfSubProduct.RfProduct.ProductType == "KUR" ? x.SubmittedPlafond : 0));
                })
                .ForMember(d => d.Scheme, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.OrderByDescending(x => x.CreatedDate).FirstOrDefault().RfSubProduct.SIKPSkema);
                })
                .ForMember(d => d.DebtorCompanyLinkageId, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.Code == "001" ? "1" : s.RfOwnerCategory.Code == "002" ? "2" : null);
                })
                .ForMember(d => d.DebtorCompanyCollaterals, o =>
                {
                    o.MapFrom(s => $"{string.Join(System.Environment.NewLine, s.LoanApplicationCollaterals.Select((x, i) => $"{i + 1}. {x.RfCollateralBC.CollateralDesc}, {x.RfDocument.DocumentDesc}, {x.DocumentNumber}, {x.LoanApplicationCollateralOwner.OwnerName}"))}");
                })
                .ForMember(d => d.DebtorNoIdentity, o =>
                {
                    o.MapFrom(s => s.Debtor.NoIdentity);
                })
                .ForMember(d => d.DebtorSectorLBU3Code, o =>
                {
                    o.MapFrom(s => s.LoanApplicationFacilities.Count > 0 ? s.LoanApplicationFacilities.OrderByDescending(x => x.CreatedDate).FirstOrDefault().SectorLBU3Code : null);
                })
                .ForMember(d => d.DebtorNPWP, o =>
                {
                    o.MapFrom(s => s.Debtor.NPWP);
                })
                .ForMember(d => d.DebtorJobId, o =>
                {
                    o.MapFrom(s => s.Debtor.JobCode);
                })
                .ForMember(d => d.Fullname, o =>
                {
                    o.MapFrom(s => s.Debtor.Fullname);
                })
                .ForMember(d => d.DateOfBirth, o =>
                {
                    o.MapFrom(s => s.Debtor.DateOfBirth);
                })
                .ForMember(d => d.DebtorGenderId, o =>
                {
                    o.MapFrom(s => s.Debtor.GenderId);
                })
                .ForMember(d => d.DebtorMaritalStatusId, o =>
                {
                    o.MapFrom(s => s.Debtor.MaritalStatusId);
                })
                .ForMember(d => d.DebtorAddress, o =>
                {
                    o.MapFrom(s => s.Debtor.Address);
                })
                .ForMember(d => d.DebtorProvince, o =>
                {
                    o.MapFrom(s => s.Debtor.RfZipCode.KodeProvinsi);
                })
                .ForMember(d => d.DebtorCity, o =>
                {
                    o.MapFrom(s => s.Debtor.RfZipCode.KodeKabKota);
                })
                .ForMember(d => d.DebtorDistrict, o =>
                {
                    o.MapFrom(s => s.Debtor.RfZipCode.KodeKecamatan);
                })
                .ForMember(d => d.DebtorNeighborhoods, o =>
                {
                    o.MapFrom(s => s.Debtor.RfZipCode.KodeKelurahan);
                })
                .ForMember(d => d.DebtorZipCode, o =>
                {
                    o.MapFrom(s => s.Debtor.RfZipCode.ZipCode);
                })
                .ForMember(d => d.DebtorZipCodeId, o =>
                {
                    o.MapFrom(s => s.Debtor.ZipCodeId);
                })
                .ForMember(d => d.DebtorCompanyAddress, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.Address);
                })
                .ForMember(d => d.DebtorCompanyProvince, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.RfZipCode.KodeProvinsi);
                })
                .ForMember(d => d.DebtorCompanyCity, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.RfZipCode.KodeKabKota);
                })
                .ForMember(d => d.DebtorCompanyDistrict, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.RfZipCode.KodeKecamatan);
                })
                .ForMember(d => d.DebtorCompanyNeighborhoods, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.RfZipCode.KodeKelurahan);
                })
                .ForMember(d => d.DebtorCompanyZipCode, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.RfZipCode.ZipCode);
                })
                .ForMember(d => d.DebtorCompanyZipCodeId, o =>
                {
                    o.MapFrom(s => s.DebtorCompany.ZipCodeId);
                });

            #region Relatives Requests
            CreateMap<LoanApplicationCreditScoringRequest, LoanApplicationCreditScoring>();
            CreateMap<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>()
                .ConstructUsing((s, c) => c.Mapper.Map<LoanApplicationCreditScoring>(s.InitialDataEntry.CreditScoring));
            #endregion
            #endregion
        }
    }
}

