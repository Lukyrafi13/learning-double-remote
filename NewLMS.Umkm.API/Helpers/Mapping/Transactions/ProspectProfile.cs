using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.Prospects;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class ProspectProfile : Profile
    {
        public ProspectProfile()
        {
            CreateMap<ProspectPostRequest, Prospect>();
            CreateMap<ProspectPutRequest, Prospect>();
            CreateMap<Prospect, ProspectResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(s => s.RfProduct))
                .ForMember(d => d.RfApplicationType, s => s.MapFrom(s => s.RfApplicationType))
                .ForMember(d => d.RfInstituteCode, s => s.MapFrom(s => s.RfInstituteCode))
                .ForMember(d => d.RfCompanyType, s => s.MapFrom(s => s.RfCompanyType))
                .ForMember(d => d.RfApplicationType, s => s.MapFrom(s => s.RfApplicationType))
                .ForMember(d => d.RfInstituteCode, s => s.MapFrom(s => s.RfInstituteCode))
                .ForMember(d => d.RfCategory, s => s.MapFrom(s => s.RfCategory));

            CreateMap<Prospect, ProspectTableResponse>()
                .ForMember(d => d.DebtorName, o =>
                {
                    o.MapFrom(s => s.Fullname);
                })
                .ForMember(d => d.OwnerCategory, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.Description);
                })
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.RfProduct.ProductDesc));

            CreateMap<Prospect, ProspectEstimatedDateResponse>().ReverseMap();
        }
    }
}