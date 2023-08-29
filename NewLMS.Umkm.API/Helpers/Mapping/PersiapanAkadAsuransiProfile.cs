using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.PersiapanAkadAsuransis;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class PersiapanAkadAsuransiProfile : Profile
    {
        public PersiapanAkadAsuransiProfile()
        {
            CreateMap<PersiapanAkadAsuransiPostRequestDto, PersiapanAkadAsuransi>();
            CreateMap<PersiapanAkadAsuransiPutRequestDto, PersiapanAkadAsuransi>();
            CreateMap<PersiapanAkadAsuransiResponseDto, PersiapanAkadAsuransi>().ReverseMap();
        }
    }
}
