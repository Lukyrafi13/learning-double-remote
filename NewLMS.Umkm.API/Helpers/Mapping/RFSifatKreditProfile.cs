using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSifatKreditProfile : Profile
    {
        public RFSifatKreditProfile()
        {
            CreateMap<RFSifatKreditPostRequestDto, RFSifatKredit>();
            CreateMap<RFSifatKreditPutRequestDto, RFSifatKredit>();
            CreateMap<RFSifatKreditResponseDto, RFSifatKredit>().ReverseMap();
        }
    }
}