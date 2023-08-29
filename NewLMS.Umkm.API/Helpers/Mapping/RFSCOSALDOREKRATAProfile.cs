using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCOSALDOREKRATAProfile : Profile
    {
        public RFSCOSALDOREKRATAProfile()
        {
            CreateMap<RFSCOSALDOREKRATAPostRequestDto, RFSCOSALDOREKRATA>();
            CreateMap<RFSCOSALDOREKRATAPutRequestDto, RFSCOSALDOREKRATA>();
            CreateMap<RFSCOSALDOREKRATAResponseDto, RFSCOSALDOREKRATA>().ReverseMap();
        }
    }
}
