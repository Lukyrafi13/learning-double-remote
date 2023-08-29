using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSiklusUsahaProfile : Profile
    {
        public RFSiklusUsahaProfile()
        {
            CreateMap<RFSiklusUsahaPostRequestDto, RFSiklusUsaha>();
            CreateMap<RFSiklusUsahaPutRequestDto, RFSiklusUsaha>();
            CreateMap<RFSiklusUsahaResponseDto, RFSiklusUsaha>().ReverseMap();
        }
    }
}