using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSifatKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping

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