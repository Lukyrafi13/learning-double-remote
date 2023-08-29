using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
