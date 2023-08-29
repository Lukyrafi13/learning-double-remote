using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBanks;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFBankProfile : Profile
    {
        public RFBankProfile()
        {
            CreateMap<RFBankPostRequestDto, RFBank>();
            CreateMap<RFBankPutRequestDto, RFBank>();
            CreateMap<RFBankResponseDto, RFBank>().ReverseMap();
        }
    }
}