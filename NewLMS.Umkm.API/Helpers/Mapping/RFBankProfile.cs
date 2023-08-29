using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBanks;

namespace NewLMS.Umkm.API.Helpers.Mapping

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