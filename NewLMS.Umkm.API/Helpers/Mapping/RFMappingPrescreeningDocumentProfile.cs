using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFMappingPrescreeningDocuments;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFMappingPrescreeningDocumentProfile : Profile
    {
        public RFMappingPrescreeningDocumentProfile()
        {
            CreateMap<RFMappingPrescreeningDocumentPostRequestDto, RFMappingPrescreeningDocument>();
            CreateMap<RFMappingPrescreeningDocumentPutRequestDto, RFMappingPrescreeningDocument>();
            CreateMap<RFMappingPrescreeningDocumentResponseDto, RFMappingPrescreeningDocument>().ReverseMap();
        }
    }
}