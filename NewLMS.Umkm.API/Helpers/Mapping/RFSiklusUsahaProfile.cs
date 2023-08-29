using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

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