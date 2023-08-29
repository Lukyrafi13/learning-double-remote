using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFDocumentAgunanProfile : Profile
    {
        public RFDocumentAgunanProfile()
        {
            CreateMap<RFDocumentAgunanPostRequestDto, RFDocumentAgunan>();
            CreateMap<RFDocumentAgunanPutRequestDto, RFDocumentAgunan>();
            CreateMap<RFDocumentAgunanResponseDto, RFDocumentAgunan>().ReverseMap();
        }
    }
}
