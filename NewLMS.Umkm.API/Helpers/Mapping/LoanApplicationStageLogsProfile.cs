using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.LoanApplicationStageLogss;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class LoanApplicationStageLogsProfile : Profile
    {
        public LoanApplicationStageLogsProfile()
        {
            CreateMap<LoanApplicationStageLogs, LoanApplicationStageLogsResponseDto>().ReverseMap();
        }
    }
}