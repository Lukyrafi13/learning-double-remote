using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class SIKPCalonDebiturProfile : Profile
    {
        public SIKPCalonDebiturProfile()
        {
            CreateMap<SIKPCalonDebiturPostRequestDto, SIKPCalonDebitur>();
            CreateMap<SIKPCalonDebiturPutRequestDto, SIKPCalonDebitur>();
            CreateMap<SIKPCalonDebiturValidasiPostRequestDto, SIKPCalonDebitur>();
            CreateMap<SIKPCalonDebiturValidasiPutRequestDto, SIKPCalonDebitur>();
            CreateMap<SIKPCalonDebiturResponseDto, SIKPCalonDebitur>().ReverseMap();
        }
    }
}