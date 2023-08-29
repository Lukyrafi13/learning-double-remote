using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisKendaraanAgunans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFJenisKendaraanAgunanProfile : Profile
    {
        public RFJenisKendaraanAgunanProfile()
        {
            CreateMap<RFJenisKendaraanAgunanPostRequestDto, RFJenisKendaraanAgunan>();
            CreateMap<RFJenisKendaraanAgunanPutRequestDto, RFJenisKendaraanAgunan>();
            CreateMap<RFJenisKendaraanAgunanResponseDto, RFJenisKendaraanAgunan>().ReverseMap();
        }
    }
}