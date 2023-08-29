using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFPolaPengembalians;

namespace NewLMS.Umkm.API.Helpers.Mapping

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