using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFVEHICLETYPEs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFVEHICLETYPEProfile : Profile
    {
        public RFVEHICLETYPEProfile()
        {
            CreateMap<RFVEHICLETYPEPostRequestDto, RFVEHICLETYPEs>();
            CreateMap<RFVEHICLETYPEPutRequestDto, RFVEHICLETYPEs>();
            CreateMap<RFVEHICLETYPEResponseDto, RFVEHICLETYPEs>().ReverseMap();
        }
    }
}