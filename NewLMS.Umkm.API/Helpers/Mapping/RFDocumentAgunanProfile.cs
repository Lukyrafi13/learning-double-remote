using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFDocumentAgunans;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
