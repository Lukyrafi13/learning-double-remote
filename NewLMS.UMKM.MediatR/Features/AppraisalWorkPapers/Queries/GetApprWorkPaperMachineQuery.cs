using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers;
using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.AppraisalWorkPapers.Queries
{
    public class GetApprWorkPaperMachineQuery : IRequest<ServiceResponse<ApprWorkPaperMachineResponse>>
    {
        public Guid AppraisalGuid;
    }

    public class GetApprWorkPaperMachineQueryHandler : IRequestHandler<GetApprWorkPaperMachineQuery, ServiceResponse<ApprWorkPaperMachineResponse>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<Parameters> _parameters;
        private IMapper _mapper;

        public GetApprWorkPaperMachineQueryHandler(
            IMapper mapper,
            IGenericRepositoryAsync<ApprWorkPaperMachineMarketSummaries> apprSummary,
            IGenericRepositoryAsync<Parameters> parameters)
        {
            _mapper = mapper;
            _apprSummary = apprSummary;
            _parameters = parameters;
        }
        public async Task<ServiceResponse<ApprWorkPaperMachineResponse>> Handle(GetApprWorkPaperMachineQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var dataVm = new ApprWorkPaperMachineResponse
                {
                    ApproachType = _mapper.Map<SimpleResponse<Guid>>(apprSummary.ApproachTypeFK),
                    ApproachTypeReference = _mapper.Map<List<SimpleResponse<Guid>>>(await _parameters.GetListByPredicate(x => x.ParameterKey == "TKKM001"))
                };

                return ServiceResponse<ApprWorkPaperMachineResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprWorkPaperMachineResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperMachineMarketSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var include = new string[] {
                    "ApproachTypeFK"
                };
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperMachineMarketSummaries()
                {
                    ApprWorkPaperMachineMarketSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", include);

            }
            return apprSummary;
        }
    }
}
