using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisKendaraanAgunans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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