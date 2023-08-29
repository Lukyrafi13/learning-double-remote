using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class SlikHistoryKreditProfile : Profile
    {
        public SlikHistoryKreditProfile()
        {
            CreateMap<SlikHistoryKreditPostRequestDto, SlikHistoryKredit>();
            CreateMap<SlikHistoryKreditPutRequestDto, SlikHistoryKredit>();
            CreateMap<SlikHistoryKreditResponseDto, SlikHistoryKredit>().ReverseMap();
        }
    }
}
