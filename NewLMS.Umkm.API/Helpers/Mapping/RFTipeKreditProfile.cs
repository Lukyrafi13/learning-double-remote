using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTipeKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping

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