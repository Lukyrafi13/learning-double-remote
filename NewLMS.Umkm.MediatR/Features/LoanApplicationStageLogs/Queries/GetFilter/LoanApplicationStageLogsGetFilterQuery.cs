using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationStageLogss;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationStageLogss.Queries
{
    public class LoanApplicationStageLogssGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationStageLogsResponseDto>>>
    {
    }

    public class GetFilterLoanApplicationStageLogsQueryHandler : IRequestHandler<LoanApplicationStageLogssGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationStageLogsResponseDto>>>
    {
        private IGenericRepositoryAsync<LoanApplicationStageLogs> _LoanApplicationStageLogs;
        private IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private IGenericRepositoryAsync<LoanApplication> _LoanApplication;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationStageLogsQueryHandler(
            IGenericRepositoryAsync<LoanApplicationStageLogs> LoanApplicationStageLogs,
            IGenericRepositoryAsync<SlikRequest> SlikRequest,
            IGenericRepositoryAsync<LoanApplication> LoanApplication,
            IMapper mapper)
        {
            _LoanApplicationStageLogs = LoanApplicationStageLogs;
            _SlikRequest = SlikRequest;
            _LoanApplication = LoanApplication;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationStageLogsResponseDto>>> Handle(LoanApplicationStageLogssGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "LoanApplication",
                "LoanApplication.RfProduct",
                "LoanApplication.RfOwnerCategories",
                "RFStages",
                "LoanApplicationStageLogs",
                "LoanApplicationStageLogs.RFStages",
                "Alasan",
            };
            var data = await _LoanApplicationStageLogs.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<LoanApplicationStageLogsResponseDto>>(data.Results);
            IEnumerable<LoanApplicationStageLogsResponseDto> dataVm;
            var listResponse = new List<LoanApplicationStageLogsResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<LoanApplicationStageLogsResponseDto>(res);

                var app = res.LoanApplication;
                
                // if( app != null ){
                //     var slikRequest = app.SlikRequest;

                //     if ( slikRequest != null ){
                //         response.StatusSLIK = (slikRequest.AdminVerified==1) ? "Result" : slikRequest.ProcessStatus == 1? "AKBL" : "Request";
                //     }
                // }

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<LoanApplicationStageLogsResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}