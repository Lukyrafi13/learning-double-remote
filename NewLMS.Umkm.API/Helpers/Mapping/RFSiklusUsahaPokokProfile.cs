using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahaPokoks;

namespace NewLMS.Umkm.API.Helpers.Mapping

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