using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.PersiapanAkads;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class PersiapanAkadProfile : Profile
    {
        public PersiapanAkadProfile()
        {
            CreateMap<PersiapanAkad, PersiapanAkadBiayaAsuransiPut>().ReverseMap();
            CreateMap<PersiapanAkad, PersiapanAkadBiayaAsuransiResponse>().ReverseMap();
        }
    }
}
