using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFRelationCols;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
