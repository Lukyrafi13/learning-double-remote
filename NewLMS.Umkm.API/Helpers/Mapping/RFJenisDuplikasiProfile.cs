using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisDuplikasis;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFJenisDuplikasiProfile : Profile
    {
        public RFJenisDuplikasiProfile()
        {
            CreateMap<RFJenisDuplikasiPostRequestDto, RFJenisDuplikasi>();
            CreateMap<RFJenisDuplikasiPutRequestDto, RFJenisDuplikasi>();
            CreateMap<RFJenisDuplikasiResponseDto, RFJenisDuplikasi>().ReverseMap();
        }
    }
}