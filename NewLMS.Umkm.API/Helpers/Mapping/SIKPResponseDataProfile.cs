using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SIKPResponseDataProfile : Profile
    {
        public SIKPResponseDataProfile()
        {
            CreateMap<SIKPResponseDataPostRequestDto, SIKPResponseData>();
            CreateMap<SIKPResponseDataPutRequestDto, SIKPResponseData>();
            CreateMap<SIKPResponseDataValidasiPostRequestDto, SIKPResponseData>();
            CreateMap<SIKPResponseDataValidasiPutRequestDto, SIKPResponseData>();
            CreateMap<SIKPResponseDataResponseDto, SIKPResponseData>().ReverseMap();
        }
    }
}