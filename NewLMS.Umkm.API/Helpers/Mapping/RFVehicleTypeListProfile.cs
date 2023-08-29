using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFVehicleTypeLists;

namespace NewLMS.UMKM.API.Helpers.Mapping

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