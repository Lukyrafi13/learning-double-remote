using AutoMapper;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RfSectorLBU2Profile : Profile
    {
        public RfSectorLBU2Profile()
        {
            CreateMap<RfSectorLBU2, RfSectorLBU2Response>()
                .ForMember(x => x.RfSectorLBU1, s => s.MapFrom(x => x.RfSectorLBU1));
            CreateMap<RfSectorLBU2PostRequest, RfSectorLBU2>();
            CreateMap<RfSectorLBU2PutRequest, RfSectorLBU2>();
            CreateMap<RfSectorLBU2DeleteRequest, RfSectorLBU2>();
        }
    }
}
