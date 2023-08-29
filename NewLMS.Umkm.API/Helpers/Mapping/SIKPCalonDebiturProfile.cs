using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SIKPCalonDebiturs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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