using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFVehicleTypeLists;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFVehicleTypeListProfile : Profile
    {
        public RFVehicleTypeListProfile()
        {
            CreateMap<RFVehicleTypeListPostRequestDto, RFVehicleTypeList>();
            CreateMap<RFVehicleTypeListPutRequestDto, RFVehicleTypeList>();
            CreateMap<RFVehicleTypeListResponseDto, RFVehicleTypeList>().ReverseMap();
        }
    }
}