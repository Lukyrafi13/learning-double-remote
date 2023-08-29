using AutoMapper;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RfSectorLBU1Profile : Profile
    {
        public RfSectorLBU1Profile()
        {
            CreateMap<RfSectorLBU1, RfSectorLBU1Response>();
            CreateMap<RfSectorLBU1PostRequest, RfSectorLBU1>();
            CreateMap<RfSectorLBU1PutRequest, RfSectorLBU1>();
            CreateMap<RfSectorLBU1DeleteRequest, RfSectorLBU1>();
        }
    }
}
