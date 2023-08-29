using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOCARATRANSAKSIs;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSCOCARATRANSAKSIProfile : Profile
    {
        public RFSCOCARATRANSAKSIProfile()
        {
            CreateMap<RFSCOCARATRANSAKSIPostRequestDto, RFSCOCARATRANSAKSI>();
            CreateMap<RFSCOCARATRANSAKSIPutRequestDto, RFSCOCARATRANSAKSI>();
            CreateMap<RFSCOCARATRANSAKSIResponseDto, RFSCOCARATRANSAKSI>().ReverseMap();
        }
    }
}
