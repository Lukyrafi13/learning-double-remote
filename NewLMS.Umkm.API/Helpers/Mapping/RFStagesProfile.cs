using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFStagess;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFStagesProfile : Profile
    {
        public RFStagesProfile()
        {
            CreateMap<RFStages, RFStagesResponseDto>().ReverseMap();
            CreateMap<RFStagesPostRequestDto, RFStages>();
            CreateMap<RFStagesPutRequestDto, RFStages>();
        }
    }
}