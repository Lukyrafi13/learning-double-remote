using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfStages;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfStageProfile : Profile
    {
        public RfStageProfile()
        {
            CreateMap<RfStage, RfStageResponseDto>().ReverseMap();
            CreateMap<RfStagePostRequestDto, RfStage>();
            CreateMap<RfStagePutRequestDto, RfStage>();
        }
    }
}