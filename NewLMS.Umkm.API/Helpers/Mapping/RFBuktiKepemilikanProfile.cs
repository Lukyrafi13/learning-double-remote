using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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