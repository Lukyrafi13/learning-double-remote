using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOSALDOREKRATAs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
