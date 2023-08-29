using AutoMapper;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSectorLBU2Profile : Profile
    {
        public RFSectorLBU2Profile()
        {
            CreateMap<RFSectorLBU2, RFSectorLBU2Response>()
                .ForMember(x => x.RFSectorLBU1, s => s.MapFrom(x => x.RFSectorLBU1));
            CreateMap<RFSectorLBU2PostRequest, RFSectorLBU2>();
            CreateMap<RFSectorLBU2PutRequest, RFSectorLBU2>();
            CreateMap<RFSectorLBU2DeleteRequest, RFSectorLBU2>();
        }
    }
}
