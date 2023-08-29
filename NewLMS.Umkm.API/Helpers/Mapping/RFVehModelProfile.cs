using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFVehModels;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFVehModelProfile : Profile
    {
        public RFVehModelProfile()
        {
            CreateMap<RFVehModelPostRequestDto, RFVehModel>();
            CreateMap<RFVehModelPutRequestDto, RFVehModel>();
            CreateMap<RFVehModelResponseDto, RFVehModel>().ReverseMap();
        }
    }
}