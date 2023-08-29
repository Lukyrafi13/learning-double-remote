using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSiklusUsahaPokokProfile : Profile
    {
        public RFSiklusUsahaPokokProfile()
        {
            CreateMap<RFSiklusUsahaPokokPostRequestDto, RFSiklusUsahaPokok>();
            CreateMap<RFSiklusUsahaPokokPutRequestDto, RFSiklusUsahaPokok>();
            CreateMap<RFSiklusUsahaPokokResponseDto, RFSiklusUsahaPokok>().ReverseMap();
        }
    }
}