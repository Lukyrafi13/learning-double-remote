using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class LoanApplicationProfile : Profile
    {
        public LoanApplicationProfile()
        {
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
                });

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
                });

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

            CreateMap<LoanApplication, LoanApplicationBaseTabResponse>();



            #region Relatives
            CreateMap<LoanApplicationCollateral, LoanApplicationCollateralResponse>();
            CreateMap<LoanApplicationCollateralOwner, LoanApplicationCollateralOwnerResponse>();
            CreateMap<LoanApplicationKeyPerson, LoanApplicationKeyPersonResponse>();
            CreateMap<LoanApplicationFacility, LoanApplicationFacilityResponse>();
            #endregion
        }
    }
}

