using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.PersiapanAkads;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
