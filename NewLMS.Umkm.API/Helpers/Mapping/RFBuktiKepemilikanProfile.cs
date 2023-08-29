using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFBuktiKepemilikanProfile : Profile
    {
        public RFBuktiKepemilikanProfile()
        {
            CreateMap<RFBuktiKepemilikanPostRequestDto, RFBuktiKepemilikan>();
            CreateMap<RFBuktiKepemilikanPutRequestDto, RFBuktiKepemilikan>();
            CreateMap<RFBuktiKepemilikanResponseDto, RFBuktiKepemilikan>().ReverseMap();
        }
    }
}