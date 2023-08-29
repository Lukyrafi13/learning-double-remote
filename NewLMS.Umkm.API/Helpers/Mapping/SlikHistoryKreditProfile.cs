using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SlikHistoryKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
