using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.ProspectStageLogss;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class ProspectStageLogsProfile : Profile
    {
        public ProspectStageLogsProfile()
        {
            CreateMap<ProspectStageLogs, ProspectStageLogsResponseDto>().ReverseMap();
        }
    }
}