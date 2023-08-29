using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTempalateAkadKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping

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