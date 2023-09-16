using System;
using AutoMapper;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class SIKPProfile : Profile
    {
        public SIKPProfile()
        {
            CreateMap<SIKPRequest, SIKPRequestResponse>()
                .ForMember(d => d.DebtorRfZipCode, o => o.MapFrom(s => s.DebtorRfZipCode))
                .ForMember(d => d.DebtorCompanyRfZipCode, o => o.MapFrom(s => s.DebtorCompanyRfZipCode))
                .ForMember(d => d.RfEducation, o => o.MapFrom(s => s.RfEducation))
                .ForMember(d => d.RfGender, o => o.MapFrom(s => s.RfGender))
                .ForMember(d => d.RfMarital, o => o.MapFrom(s => s.RfMarital))
                .ForMember(d => d.RfSectorLBU3, o => o.MapFrom(s => s.RfSectorLBU3))
                .ForMember(d => d.RfJob, o => o.MapFrom(s => s.RfJob))
                .ForMember(d => d.DebtorCompanyRfLinkage, o => o.MapFrom(s => s.DebtorCompanyRfLinkage));
            CreateMap<SIKPResponse, SIKPResponseResponse>()
                .ForMember(d => d.DebtorRfZipCode, o => o.MapFrom(s => s.DebtorRfZipCode))
                .ForMember(d => d.DebtorCompanyRfZipCode, o => o.MapFrom(s => s.DebtorCompanyRfZipCode))
                .ForMember(d => d.RfEducation, o => o.MapFrom(s => s.RfEducation))
                .ForMember(d => d.RfGender, o => o.MapFrom(s => s.RfGender))
                .ForMember(d => d.RfMarital, o => o.MapFrom(s => s.RfMarital))
                .ForMember(d => d.DebtorCompanyRfLinkage, o => o.MapFrom(s => s.DebtorCompanyRfLinkage));

            CreateMap<Data.Entities.SIKP, SIKPBaseResponse>()
                .ForMember(d => d.CIF, o => o.MapFrom(s => s.LoanApplication.Debtor.CIF))
                .ForMember(d => d.RfOwnerCategory, o => o.MapFrom(s => s.LoanApplication.RfOwnerCategory))
                .ForMember(d => d.SIKPRequest, o => o.MapFrom(s => s.SIKPRequest))
                .ForMember(d => d.SIKPResponse, o => o.MapFrom(s => s.SIKPResponse));

            CreateMap<Data.Entities.SIKP, SIKPTableResponse>()
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.SIKPRequest.Fullname));
            CreateMap<SIKPRequestRequest, SIKPRequest>();

            CreateMap<DetailCalonDebiturResponseModel, SIKPResponse>()
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.tgl_lahir))
                .ForMember(d => d.DebtorAddress, o => o.MapFrom(s => s.alamat))
                .ForMember(d => d.Fullname, o => o.MapFrom(s => s.nama))
                .ForMember(d => d.DebtorNoIdentity, o => o.MapFrom(s => s.nik))
                .ForMember(d => d.DebtorNPWP, o => o.MapFrom(s => s.npwp))
                .ForMember(d => d.DebtorCompanySubisdyStatus, o => o.MapFrom(s => s.is_subsidized))
                .ForMember(d => d.DebtorCompanyPreviousSubsidy, o => o.MapFrom(s => s.subsidi_sebelumnya))
                .ForMember(d => d.DebtorCompanyCreditValue, o => o.MapFrom(s => s.jml_kredit))
                .ForMember(d => d.DebtorCompanyEmployee, o => o.MapFrom(s => s.jml_pekerja))
                .ForMember(d => d.DebtorZipCode, o => o.MapFrom(s => s.kode_pos))
                .ForMember(d => d.DebtorCompanyPhone, o => o.MapFrom(s => s.no_hp))
                .ForMember(d => d.DebtorCompanyCollaterals, o => o.MapFrom(s => s.uraian_agunan))
                .ForMember(d => d.DebtorCompanyAddress, o => o.MapFrom(s => s.alamat_usaha))
		;
        }
    }
}

