using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFMappingPrescreeningDocuments;

namespace NewLMS.UMKM.API.Helpers.Mapping

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