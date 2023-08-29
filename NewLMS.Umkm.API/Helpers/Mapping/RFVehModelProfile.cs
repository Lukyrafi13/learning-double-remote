using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFVehModels;

namespace NewLMS.Umkm.API.Helpers.Mapping

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