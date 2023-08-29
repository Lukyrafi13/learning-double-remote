using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOLOKTEMPATUSAHAs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCOLOKTEMPATUSAHAProfile : Profile
    {
        public RFSCOLOKTEMPATUSAHAProfile()
        {
            CreateMap<RFSCOLOKTEMPATUSAHAPostRequestDto, RFSCOLOKTEMPATUSAHA>();
            CreateMap<RFSCOLOKTEMPATUSAHAPutRequestDto, RFSCOLOKTEMPATUSAHA>();
            CreateMap<RFSCOLOKTEMPATUSAHAResponseDto, RFSCOLOKTEMPATUSAHA>().ReverseMap();
        }
    }
}
