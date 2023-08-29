using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisUsahaYangDihindariProfile : Profile
    {
        public RFJenisUsahaYangDihindariProfile()
        {
            CreateMap<RFJenisUsahaYangDihindariPostRequestDto, RFJenisUsahaYangDihindari>();
            CreateMap<RFJenisUsahaYangDihindariPutRequestDto, RFJenisUsahaYangDihindari>();
            CreateMap<RFJenisUsahaYangDihindariResponseDto, RFJenisUsahaYangDihindari>().ReverseMap();
        }
    }
}