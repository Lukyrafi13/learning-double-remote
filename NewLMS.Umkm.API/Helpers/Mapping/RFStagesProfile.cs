using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFStagess;

namespace NewLMS.Umkm.API.Helpers.Mapping

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