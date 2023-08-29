using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFMappingLBU3s;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFMappingLBU3Profile : Profile
    {
        public RFMappingLBU3Profile()
        {
            CreateMap<RFMappingLBU3PostRequestDto, RFMappingLBU3>();
            CreateMap<RFMappingLBU3PutRequestDto, RFMappingLBU3>();
            CreateMap<RFMappingLBU3ResponseDto, RFMappingLBU3>().ReverseMap();
        }
    }
}