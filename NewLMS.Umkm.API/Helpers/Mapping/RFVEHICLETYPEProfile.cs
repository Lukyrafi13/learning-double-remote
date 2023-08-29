using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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