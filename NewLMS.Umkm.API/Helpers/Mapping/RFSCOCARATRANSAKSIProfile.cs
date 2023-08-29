using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
