using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.ProspectStageLogss;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class ProspectStageLogsProfile : Profile
    {
        public ProspectStageLogsProfile()
        {
            CreateMap<ProspectStageLogs, ProspectStageLogsResponseDto>().ReverseMap();
        }
    }
}