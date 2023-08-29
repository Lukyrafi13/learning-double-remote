using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFPolaPengembalians;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFPolaPengembalianProfile : Profile
    {
        public RFPolaPengembalianProfile()
        {
            CreateMap<RFPolaPengembalian, RFPolaPengembalianResponseDto>().ReverseMap();
            CreateMap<RFPolaPengembalianPostRequestDto, RFPolaPengembalian>();
            CreateMap<RFPolaPengembalianPutRequestDto, RFPolaPengembalian>();
        }
    }
}