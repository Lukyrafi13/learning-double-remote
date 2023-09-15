using System;
using AutoMapper;
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
                .ForMember(d => d.DebtorCompanyRfLinkage, o => o.MapFrom(s => s.DebtorCompanyRfLinkage));
            CreateMap<SIKPResponse, SIKPResponseResponse>()
                .ForMember(d => d.DebtorRfZipCode, o => o.MapFrom(s => s.DebtorRfZipCode))
                .ForMember(d => d.DebtorCompanyRfZipCode, o => o.MapFrom(s => s.DebtorCompanyRfZipCode))
                .ForMember(d => d.RfEducation, o => o.MapFrom(s => s.RfEducation))
                .ForMember(d => d.RfGender, o => o.MapFrom(s => s.RfGender))
                .ForMember(d => d.RfMarital, o => o.MapFrom(s => s.RfMarital))
                .ForMember(d => d.DebtorCompanyRfLinkage, o => o.MapFrom(s => s.DebtorCompanyRfLinkage));

            CreateMap<Data.Entities.SIKP, SIKPBaseResponse>()
                .ForMember(d => d.SIKPRequest, o => o.MapFrom(s => s.SIKPRequest))
                .ForMember(d => d.SIKPResponse, o => o.MapFrom(s => s.SIKPResponse));

            CreateMap<Data.Entities.SIKP, SIKPTableResponse>()
		        .ForMember(d => d.Fullname, o => o.MapFrom(s => s.SIKPRequest.Fullname));
        }
    }
}

