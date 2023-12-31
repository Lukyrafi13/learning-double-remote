﻿using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalMachine;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprMachineTemplateProfile : Profile
    {
        public ApprMachineTemplateProfile()
        {
            CreateMap<ApprMachineTemplate, ApprMachineTemplateResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.KotaKabupaten, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces));
        }
    }
}
