using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTempalateAkadKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFTempalateAkadKreditProfile : Profile
    {
        public RFTempalateAkadKreditProfile()
        {
            CreateMap<RFTempalateAkadKredit, RFTempalateAkadKreditResponseDto>().ReverseMap();
            CreateMap<RFTempalateAkadKreditPostRequestDto, RFTempalateAkadKredit>();
            CreateMap<RFTempalateAkadKreditPutRequestDto, RFTempalateAkadKredit>();
        }
    }
}