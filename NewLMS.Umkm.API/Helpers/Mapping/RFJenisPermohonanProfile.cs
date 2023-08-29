using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisPermohonanProfile : Profile
    {
        public RFJenisPermohonanProfile()
        {
            CreateMap<RFJenisPermohonan, RFJenisPermohonanResponseDto>().ReverseMap();
            CreateMap<RFJenisPermohonanPostRequestDto, RFJenisPermohonan>();
            CreateMap<RFJenisPermohonanPutRequestDto, RFJenisPermohonan>();
        }
    }
}