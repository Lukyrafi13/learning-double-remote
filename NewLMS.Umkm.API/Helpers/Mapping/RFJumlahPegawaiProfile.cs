using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJumlahPegawais;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJumlahPegawaiProfile : Profile
    {
        public RFJumlahPegawaiProfile()
        {
            CreateMap<RFJumlahPegawaiPostRequestDto, RFJumlahPegawai>();
            CreateMap<RFJumlahPegawaiPutRequestDto, RFJumlahPegawai>();
            CreateMap<RFJumlahPegawaiResponseDto, RFJumlahPegawai>().ReverseMap();
        }
    }
}