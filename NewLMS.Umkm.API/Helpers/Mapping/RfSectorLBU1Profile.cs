using AutoMapper;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSectorLBU1Profile : Profile
    {
        public RFSectorLBU1Profile()
        {
            CreateMap<RFSectorLBU1, RFSectorLBU1Response>();
            CreateMap<RFSectorLBU1PostRequest, RFSectorLBU1>();
            CreateMap<RFSectorLBU1PutRequest, RFSectorLBU1>();
            CreateMap<RFSectorLBU1DeleteRequest, RFSectorLBU1>();
        }
    }
}
