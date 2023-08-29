using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
