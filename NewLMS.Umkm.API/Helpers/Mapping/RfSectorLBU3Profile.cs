using AutoMapper;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSectorLBU3Profile : Profile
    {
        public RFSectorLBU3Profile()
        {
            CreateMap<RFSectorLBU3, RFSectorLBU3Response>()
                .ForMember(x => x.RFSectorLBU2, s => s.MapFrom(x => x.RFSectorLBU2));
            CreateMap<RFSectorLBU3PostRequest, RFSectorLBU3>();
            CreateMap<RFSectorLBU3PutRequest, RFSectorLBU3>();
            CreateMap<RFSectorLBU3DeleteRequest, RFSectorLBU3>();
        }
    }
}
