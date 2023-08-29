using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFDocuments;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
