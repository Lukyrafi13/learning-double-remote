using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJumlahPegawais;

namespace NewLMS.UMKM.API.Helpers.Mapping

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