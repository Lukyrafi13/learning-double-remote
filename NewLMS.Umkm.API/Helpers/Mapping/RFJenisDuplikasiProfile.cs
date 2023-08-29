using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;

namespace NewLMS.Umkm.API.Helpers.Mapping

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