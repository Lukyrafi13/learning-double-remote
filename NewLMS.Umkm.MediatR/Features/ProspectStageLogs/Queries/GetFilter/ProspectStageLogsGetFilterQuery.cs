using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ProspectStageLogss;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.ProspectStageLogss.Queries
{
    public class ProspectStageLogssGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ProspectStageLogsResponseDto>>>
    {
    }

    public class GetFilterProspectStageLogsQueryHandler : IRequestHandler<ProspectStageLogssGetFilterQuery, PagedResponse<IEnumerable<ProspectStageLogsResponseDto>>>
    {
        private IGenericRepositoryAsync<ProspectStageLogs> _ProspectStageLogs;
        private IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private IGenericRepositoryAsync<App> _App;
        private readonly IMapper _mapper;

        public GetFilterProspectStageLogsQueryHandler(
            IGenericRepositoryAsync<ProspectStageLogs> ProspectStageLogs,
            IGenericRepositoryAsync<SlikRequest> SlikRequest,
            IGenericRepositoryAsync<App> App,
            IMapper mapper)
        {
            _ProspectStageLogs = ProspectStageLogs;
            _SlikRequest = SlikRequest;
            _App = App;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProspectStageLogsResponseDto>>> Handle(ProspectStageLogssGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "Prospect.App",
                "Prospect.App.SlikRequest",
                "Prospect.JenisProduk",
                "Prospect.TipeDebitur",
                "RFStages",
                "ProspectStageLogs",
                "ProspectStageLogs.RFStages",
                "Alasan",
            };
            var data = await _ProspectStageLogs.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<ProspectStageLogsResponseDto>>(data.Results);
            IEnumerable<ProspectStageLogsResponseDto> dataVm;
            var listResponse = new List<ProspectStageLogsResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<ProspectStageLogsResponseDto>(res);

                var app = res.Prospect.App;
                
                if( app != null ){
                    var slikRequest = app.SlikRequest;

                    if ( slikRequest != null ){
                        response.StatusSLIK = (slikRequest.AdminVerified==1) ? "Result" : slikRequest.ProcessStatus == 1? "AKBL" : "Request";
                    }
                }

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<ProspectStageLogsResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}