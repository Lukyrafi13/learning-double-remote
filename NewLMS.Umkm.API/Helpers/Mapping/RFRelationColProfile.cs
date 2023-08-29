using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFRelationCols;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFRelationColProfile : Profile
    {
        public RFRelationColProfile()
        {
            CreateMap<RFRelationColPostRequestDto, RFRelationCol>();
            CreateMap<RFRelationColPutRequestDto, RFRelationCol>();
            CreateMap<RFRelationColResponseDto, RFRelationCol>().ReverseMap();
        }
    }
}
