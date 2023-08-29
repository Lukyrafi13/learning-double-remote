using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFTipeKreditProfile : Profile
    {
        public RFTipeKreditProfile()
        {
            CreateMap<RFTipeKreditPostRequestDto, RFTipeKredit>();
            CreateMap<RFTipeKreditPutRequestDto, RFTipeKredit>();
            CreateMap<RFTipeKreditResponseDto, RFTipeKredit>().ReverseMap();
        }
    }
}