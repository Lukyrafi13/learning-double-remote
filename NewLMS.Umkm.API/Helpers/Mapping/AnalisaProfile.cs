﻿using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Analisas;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class AnalisaProfile : Profile
    {
        public AnalisaProfile()
        {
            CreateMap<Analisa, AnalisaInformasiUsahaPut>().ReverseMap();
            CreateMap<Analisa, AnalisaInformasiUsahaResponse>().ReverseMap();

            CreateMap<Analisa, AnalisaHubunganBankPut>().ReverseMap();
            CreateMap<Analisa, AnalisaHubunganBankResponse>().ReverseMap();
            
            CreateMap<Analisa, AnalisaKemampuanMembayarPut>().ReverseMap();
            CreateMap<Analisa, AnalisaKemampuanMembayarResponse>().ReverseMap();

            CreateMap<Analisa, AnalisaInformasiPencairanPut>().ReverseMap();
            CreateMap<Analisa, AnalisaInformasiPencairanResponse>().ReverseMap();
            
            CreateMap<Analisa, AnalisaHasilRekomendasiPut>().ReverseMap();
            CreateMap<Analisa, AnalisaHasilRekomendasiResponse>().ReverseMap();
            
            CreateMap<Analisa, AnalisaHasilRekomendasiSiklusPut>().ReverseMap();
            CreateMap<Analisa, AnalisaHasilRekomendasiSiklusResponse>().ReverseMap();
            
            CreateMap<Analisa, AnalisaComplianceSheetPut>().ReverseMap();
            CreateMap<Analisa, AnalisaComplianceSheetResponse>().ReverseMap();
        }
    }
}
