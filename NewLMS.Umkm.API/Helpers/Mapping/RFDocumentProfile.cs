using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFDocuments;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFDocumentProfile : Profile
    {
        public RFDocumentProfile()
        {
            CreateMap<RFDocumentPostRequestDto, RFDocument>();
            CreateMap<RFDocumentPutRequestDto, RFDocument>();
            CreateMap<RFDocumentResponseDto, RFDocument>().ReverseMap();
        }
    }
}
