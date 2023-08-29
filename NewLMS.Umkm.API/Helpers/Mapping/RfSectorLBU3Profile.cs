using AutoMapper;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RfSectorLBU3Profile : Profile
    {
        public RfSectorLBU3Profile()
        {
            CreateMap<RfSectorLBU3, RfSectorLBU3Response>()
                .ForMember(x => x.RfSectorLBU2, s => s.MapFrom(x => x.RfSectorLBU2));
            CreateMap<RfSectorLBU3PostRequest, RfSectorLBU3>();
            CreateMap<RfSectorLBU3PutRequest, RfSectorLBU3>();
            CreateMap<RfSectorLBU3DeleteRequest, RfSectorLBU3>();
        }
    }
}
